--If you are going to submit these queries in SoftUni Judge system, remove GO tags.

--Task 1
CREATE PROC usp_GetEmployeesSalaryAbove35000 AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END
GO

--Task 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18,4)) AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @minSalary
END
GO

--Task 3
CREATE PROC usp_GetTownsStartingWith(@startsWith NVARCHAR(30)) AS
BEGIN
	SELECT Name
	FROM Towns
	WHERE Name LIKE @startsWith + '%'
END
GO

--Task 4
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(30)) AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @townName
END
GO

--Task 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7) AS
BEGIN
	DECLARE @level VARCHAR(7)
	IF (@salary < 30000) SET @level = 'Low'
	ELSE IF (@salary <= 50000) SET @level = 'Average'
	ELSE SET @level = 'High'
	RETURN @level
END
GO

--Task 6
CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(7)) AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @level
END
GO

--Task 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(50))
RETURNS BIT AS
BEGIN
	IF @word LIKE '%[^' + @setOfLetters + ']%'
		RETURN 0
	RETURN 1
END
GO

--Task 8
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
BEGIN
	DECLARE @newManager INT = (SELECT e.ManagerID FROM Departments d JOIN Employees e ON d.ManagerID = e.EmployeeID WHERE d.DepartmentID = @departmentId)

	UPDATE d
	SET d.ManagerID = @newManager
	FROM Departments d JOIN Employees e ON d.ManagerID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId

	UPDATE e
	SET e.ManagerID = @newManager
	FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID
	WHERE e.DepartmentID != @departmentId AND m.DepartmentID = @departmentId

	DELETE FROM ep
	FROM EmployeesProjects ep JOIN Employees e ON ep.EmployeeID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId

	DELETE FROM Employees WHERE DepartmentID = @departmentId
	DELETE FROM Departments WHERE DepartmentID = @departmentId
	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId
END
GO

--Task 9
CREATE PROC usp_GetHoldersFullName AS
BEGIN
	SELECT FirstName + ' ' + LastName
	FROM AccountHolders
END
GO

--Task 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@higherThan MONEY) AS
BEGIN
	SELECT h.FirstName, h.LastName
	FROM AccountHolders h
	JOIN Accounts a ON h.Id = a.AccountHolderId
	GROUP BY h.Id, h.FirstName, h.LastName
	HAVING SUM(a.Balance) > @higherThan
	ORDER BY h.LastName, h.FirstName
END
GO

--Task 11
CREATE FUNCTION ufn_CalculateFutureValue(@i DECIMAL(15,4), @r FLOAT, @T INT)
RETURNS DECIMAL(15, 4) AS
BEGIN
	RETURN @i*(POWER(1 + @r, @t))
END
GO

--Task 12
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT) AS
BEGIN
	SELECT a.Id, h.FirstName, h.LastName, a.Balance, dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	FROM Accounts a
	JOIN AccountHolders h ON a.AccountHolderId = h.Id
	WHERE a.Id = @accountId
END
GO

--Task 13
CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS @Table TABLE(SumCash MONEY) AS
BEGIN
	INSERT INTO @Table
	SELECT SUM(Cash) 
	FROM
	(SELECT GameId, Cash,
    ROW_NUMBER() OVER (PARTITION BY GameId ORDER BY Cash DESC) AS Row
    FROM UsersGames ug
    JOIN Games g ON ug.GameId = g.Id
    WHERE g.Name = @GameName) as g
    WHERE (Row % 2 = 1)
	RETURN
END
GO

--Task 14
CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted i, deleted d
END
GO

--Task 15
CREATE TRIGGER tr_LogsUpdate ON Logs FOR INSERT AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, Subject, Body)
	SELECT AccountId,
		CONCAT('Balance change for account: ', AccountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ',
			OldSum, ' to ', NewSum, '.')
	FROM inserted
END
GO

--Task 16
CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY) AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
	COMMIT
GO

--Task 17
CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY) AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

	DECLARE @NewBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF(@NewBalance < 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
GO

--Task 18
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @MoneyAmount MONEY) AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @SenderId

	DECLARE @NewBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @SenderId)

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @ReceiverId

	IF(@NewBalance < 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
GO

--Task 20
DECLARE @UserGameId INT = 
(SELECT ug.Id
FROM UsersGames ug
JOIN Games g ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
WHERE g.Name = 'Safflower' AND u.Username = 'Stamat')

DECLARE @TotalAmount MONEY
DECLARE @Cash MONEY

BEGIN TRANSACTION

SET @TotalAmount = 
(SELECT SUM(Price)
FROM Items
WHERE MinLevel BETWEEN 11 AND 12)

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT Id, @UserGameId
FROM Items
WHERE MinLevel BETWEEN 11 AND 12

SET @Cash =
(SELECT Cash
FROM UsersGames
WHERE Id = @UserGameId)

IF(@Cash - @TotalAmount < 0)
	ROLLBACK
ELSE BEGIN
	UPDATE UsersGames
	SET Cash -= @TotalAmount
	WHERE Id = @UserGameId
	COMMIT
END

BEGIN TRANSACTION

SET @TotalAmount = 
(SELECT SUM(Price)
FROM Items
WHERE MinLevel BETWEEN 19 AND 21)

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT Id, @UserGameId
FROM Items
WHERE MinLevel BETWEEN 19 AND 21

SET @Cash =
(SELECT Cash
FROM UsersGames
WHERE Id = @UserGameId)
 
IF(@Cash - @TotalAmount < 0)
	ROLLBACK
ELSE BEGIN
	UPDATE UsersGames
	SET Cash -= @TotalAmount
	WHERE Id = @UserGameId
	COMMIT
END

SELECT i.Name
FROM UserGameItems AS ui
JOIN Items i ON i.Id = ui.ItemId
WHERE ui.UserGameId = @UserGameId
ORDER BY i.Name ASC
GO

--Task 21
CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) AS
BEGIN TRANSACTION
INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES
(@emloyeeId, @projectID)

DECLARE @Count INT =
(SELECT COUNT(*)
FROM EmployeesProjects
WHERE EmployeeID = @emloyeeId)

IF @Count > 3
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
END

COMMIT
GO

--Task 22
CREATE TRIGGER tr_EmployeesDelete ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary)
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
FROM deleted
GO