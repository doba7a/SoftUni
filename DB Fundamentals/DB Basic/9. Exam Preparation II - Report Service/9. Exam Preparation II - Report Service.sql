CREATE DATABASE ReportService
GO

USE ReportService
GO

--Task 1
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	Birthdate DATETIME,
	Age INT,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	Birthdate DATETIME,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL	
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200),
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
)

--Task 2
INSERT INTO Employees(FirstName, LastName, Gender, Birthdate, DepartmentId)
VALUES('Marlo', 'O’Malley', 'M', '9/21/1958', 1),
	('Niki', 'Stanaghan', 'F', '11/26/1969', 4),
	('Ayrton', 'Senna', 'M', '03/21/1960', 9),
	('Ronnie', 'Peterson', 'M', '02/14/1944', 9),
	('Giovanna', 'Amati', 'F', '07/20/1959', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES(1, 1, '04/13/2017', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '09/05/2015', '12/06/2015', 'Charity trail running', 3, 5),
	(14, 2, '09/07/2015', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', 1, 1)

--Task 3
UPDATE Reports
SET StatusId = 2
WHERE StatusId = 1 AND CategoryId = 4

--Task 4
DELETE Reports
WHERE StatusId = 4

--Task 5
SELECT Username, Age
FROM Users
ORDER BY Age, Username DESC

--Task 6
SELECT [Description], OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

--Task 7
SELECT e.FirstName, e.LastName, r.[Description], FORMAT(r.OpenDate, 'yyyy-MM-dd')
FROM Employees AS e
JOIN Reports AS r
ON r.EmployeeId = e.Id
ORDER BY e.Id, r.OpenDate, r.Id

--Task 8
SELECT c.[Name], COUNT(r.Id) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r
ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

--Task 9
SELECT c.[Name], COUNT(e.Id) AS [Employees Number]
FROM Categories AS c
JOIN Departments AS d
ON d.Id = c.DepartmentId
JOIN Employees AS e
ON e.DepartmentId = d.Id
GROUP BY c.[Name]
ORDER BY c.[Name]

--Task 10
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name], COUNT (DISTINCT r.UserId) AS [Users Number]
FROM Employees AS e
LEFT JOIN Reports AS r
ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Users Number] DESC, [Name]

--Task 11
SELECT r.OpenDate, r.[Description], u.Email AS [Reporter Email]
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
JOIN Users AS u
ON u.Id = r.UserId
WHERE r.CloseDate IS NULL 
	AND LEN(r.[Description]) > 20
	AND r.[Description] LIKE '%str%'
	AND c.DepartmentId IN (1, 4, 5)
ORDER BY r.OpenDate, u.Email, r.Id

--Task 12
SELECT c.[Name]
FROM Categories AS c
LEFT JOIN Reports AS r
ON r.CategoryId = c.Id
LEFT JOIN Users AS u
ON u.Id = r.UserId
WHERE DAY(u.Birthdate) = DAY(r.OpenDate)
	AND MONTH(u.Birthdate) = MONTH(r.OpenDate)
GROUP BY c.[Name]
ORDER BY c.[Name]

--Task 13
SELECT DISTINCT u.Username
FROM Reports AS r
JOIN Users AS u
ON u.Id = r.UserId
WHERE u.Username LIKE '[0-9]%' AND CAST(r.CategoryId AS VARCHAR) = LEFT(u.Username, 1)
	OR u.Username LIKE '%[0-9]' AND CAST(r.CategoryId AS VARCHAR) = RIGHT(u.Username, 1)
ORDER BY u.Username

--Task 14
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name], 
	   ISNULL(CONVERT(VARCHAR, CC.ReportSum), '0') + '/' +        
       ISNULL(CONVERT(VARCHAR, OC.ReportSum), '0') AS [Closed Open Reports]
FROM Employees AS E
JOIN (SELECT EmployeeId,  COUNT(1) AS ReportSum
	  FROM Reports R
	  WHERE  YEAR(OpenDate) = 2016
	  GROUP BY EmployeeId) AS OC ON OC.Employeeid = E.Id
LEFT JOIN (SELECT EmployeeId,  COUNT(1) AS ReportSum
	       FROM Reports R
	       WHERE  YEAR(CloseDate) = 2016
	       GROUP BY EmployeeId) AS CC ON CC.Employeeid = E.Id
ORDER BY [Name]

--Task 15
SELECT d.[Name] AS Departmentname,
       ISNULL(CONVERT(VARCHAR, AVG(DATEDIFF(DAY, r.Opendate, r.Closedate))), 'no info') AS AverageTime
FROM Departments AS d
JOIN Categories AS c
ON c.DepartmentId = d.Id
JOIN Reports AS r
ON r.CategoryId = c.Id
GROUP BY d.[Name]
ORDER BY d.[Name]

--Task 16
SELECT Department, Category, [Percentage]
FROM (SELECT D.Name AS Department,
		    C.Name AS Category,
		    CAST(ROUND(COUNT(1) OVER(PARTITION BY C.Id) * 100.00 / COUNT(1) OVER(PARTITION BY D.Id), 0) as int) AS Percentage
     FROM Categories AS C
		  JOIN Reports AS R 
		  ON R.Categoryid = C.Id
		  JOIN Departments AS D 
		  ON D.Id = C.Departmentid
)AS [Stats]
GROUP BY Department, Category, [Percentage]
ORDER BY Department, Category,[Percentage]

--Task 17
GO
CREATE OR ALTER FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	DECLARE @ret INT = (SELECT COUNT(r.StatusId)
		FROM Reports AS r
		WHERE r.EmployeeId = @employeeId AND r.StatusId = @statusId)

	IF (@ret IS NULL)
	BEGIN
		SET @ret = 0
	END

	RETURN @ret
END

--Task 18
GO
CREATE PROCEDURE usp_AssignEmployeeToReport @employeeId INT, @reportId INT
AS
BEGIN
	BEGIN TRANSACTION

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId

	DECLARE @employeeDepartment INT = (SELECT DepartmentId
		FROM Employees
		WHERE Id = @employeeId)

	DECLARE @reportDepartment INT = (SELECT c.DepartmentId
		FROM Reports AS r
		JOIN Categories AS c
		ON c.Id = r.CategoryId
		WHERE r.Id = @reportId)

	IF (@employeeDepartment <> @reportDepartment)
	BEGIN
		ROLLBACK
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	COMMIT
END

--Task 19
GO
CREATE OR ALTER TRIGGER tr_CloseReports ON Reports FOR UPDATE
AS
BEGIN
	UPDATE Reports
	SET StatusId = (SELECT Id FROM [Status] WHERE Label = 'completed')
	WHERE Id IN (SELECT Id FROM inserted
			     WHERE Id IN (SELECT Id FROM deleted
						      WHERE CloseDate IS NULL)
			           AND CloseDate IS NOT NULL)   
END

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;
