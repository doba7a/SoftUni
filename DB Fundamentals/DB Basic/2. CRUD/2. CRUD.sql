--If you are going to submit these queries in SoftUni Judge system, remove GO tags.
USE SoftUni
GO

--Task 2
SELECT * 
FROM Departments
GO

--Task 3
SELECT [Name] 
FROM Departments
GO

--Task 4
SELECT FirstName, LastName, Salary 
FROM Employees
GO

--Task 5
SELECT FirstName, MiddleName, LastName 
FROM Employees
GO

--Task 6
SELECT FirstName + '.' + LastName + '@softuni.bg'
AS 'Full Email Address'
FROM Employees
GO

--Task 7
SELECT DISTINCT Salary
FROM Employees
GO

--Task 8
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'
GO

--Task 9
SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
GO

--Task 10
SELECT FirstName + ' ' + MiddleName + ' ' + LastName
AS 'Full Name'
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
GO

--Task 11
SELECT FirstName, LastName 
FROM Employees
WHERE ManagerID IS NULL
GO

--Task 12
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC
GO

--Task 13
SELECT TOP(5) FirstName, LastName
FROM Employees
ORDER BY Salary DESC
GO

--Task 14
SELECT FirstName, LastName
FROM Employees
WHERE DepartmentID != 4
GO

--Task 15
SELECT *
FROM Employees
ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC
GO

--Task 16
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees
GO

--Task 17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS 'Full Name', JobTitle
FROM Employees
GO

--Task 18
SELECT DISTINCT JobTitle
FROM Employees
GO

--Task 19
SELECT TOP(10) *
FROM Projects
ORDER BY StartDate ASC, Name ASC
GO

--Task 20
SELECT TOP(7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC
GO

--Task 21
UPDATE Employees
SET Salary = Salary + Salary * 0.12
WHERE DepartmentID IN(1, 2, 4, 11)
GO

SELECT Salary
FROM Employees
GO

--Task 22
USE Geography
GO

SELECT PeakName
FROM Peaks
ORDER BY PeakName ASC
GO

--Task 23
SELECT TOP(30) CountryName, [Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName ASC
GO

--Task 24
SELECT CountryName, CountryCode,
 CASE
  WHEN CurrencyCode = 'EUR' THEN 'Euro'
  ELSE 'Not Euro'
 END AS Currency
FROM Countries
ORDER BY CountryName ASC

--Task 25
USE Diablo
GO

SELECT Name
FROM Characters
ORDER BY Name ASC
GO