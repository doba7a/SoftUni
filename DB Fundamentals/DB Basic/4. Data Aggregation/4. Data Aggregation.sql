--If you are going to submit these queries in SoftUni Judge system, remove GO tags.
USE Gringotts
GO

--Task 1
SELECT COUNT(*) AS [Count]
FROM WizzardDeposits
GO

--Task 2
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GO

--Task 3
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup
GO

--Task 4
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
GO

--Task 5
SELECT DepositGroup, Sum(DepositAmount) AS [Total Sum]
FROM WizzardDeposits
GROUP BY DepositGroup
GO

--Task 6
SELECT e.DepositGroup, Sum(e.DepositAmount) AS [Total Sum]
FROM WizzardDeposits AS e
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY e.DepositGroup
GO

--Task 7
SELECT e.DepositGroup, Sum(e.DepositAmount) AS [Total Sum]
FROM WizzardDeposits AS e
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY e.DepositGroup
HAVING Sum(e.DepositAmount) < 150000
ORDER BY Sum(e.DepositAmount) DESC
GO

--Task 8
SELECT e.DepositGroup, e.MagicWandCreator, MIN(e.DepositCharge)
FROM WizzardDeposits AS e
GROUP BY e.DepositGroup, e.MagicWandCreator
ORDER BY e.MagicWandCreator ASC, e.DepositGroup ASC
GO

--Task 9
SELECT e.AgeGroups, COUNT(*) AS WizzardsCount
FROM
(SELECT CASE
   WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
   WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
   WHEN Age >= 61 THEN '[61+]'
   ELSE 'N\A'
  END AS AgeGroups
 FROM WizzardDeposits) AS e
GROUP BY e.AgeGroups
GO

--Task 10
SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName
GO

--Task 11
SELECT DepositGroup, 
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate >= '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC
GO

--Task 12
SELECT SUM(e.Diff) AS TotalSum 
FROM (SELECT DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Diff FROM WizzardDeposits) AS e
GO

--Task 13
USE SoftUni
GO

SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID
GO

--Task 14
SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate >= '01/01/2000'
GROUP BY DepartmentID
GO

--Task 15
SELECT * INTO EmployeesAverageSalaries
FROM Employees
WHERE Salary > 30000
GO

DELETE
FROM EmployeesAverageSalaries
WHERE ManagerID = 42
GO

UPDATE EmployeesAverageSalaries
SET Salary += 5000
WHERE DepartmentID = 1
GO

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesAverageSalaries
GROUP BY DepartmentID
GO

--Task 16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000
GO

--Task 17
SELECT COUNT(*) AS [Count]
FROM (SELECT Salary FROM Employees WHERE ManagerID IS NULL) AS EmployeesWithoutManager
GO

--Task 18
SELECT DISTINCT DepartmentID, Salary
FROM 
(
SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
FROM Employees
) AS e
WHERE SalaryRank = 3	
GO

--Task 19
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS emp
WHERE Salary > (SELECT AVG(Salary) FROM Employees WHERE DepartmentID = emp.DepartmentID)
ORDER BY DepartmentID
GO

