--If you are going to submit these queries in SoftUni Judge system, remove GO tags.
USE SoftUni
GO

--Task 1
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'sa%'
GO

--Task 2
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'
GO

--Task 3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10) 
AND HireDate BETWEEN '1995-01-01' AND '2005-12-31'
GO

--Task 4
SELECT FirstName, LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'
GO

--Task 5
SELECT Name
FROM Towns
WHERE LEN(Name) = 5 
OR Len(Name) = 6
ORDER BY Name ASC
GO

--Task 6
SELECT *
FROM Towns
WHERE Name LIKE 'M%'
OR Name LIKE 'K%'
OR Name LIKE 'B%'
OR Name LIKE 'E%'
ORDER BY Name ASC
GO

--Task 7
SELECT *
FROM Towns
WHERE NOT Name LIKE 'R%'
AND NOT Name LIKE 'B%'
AND NOT Name LIKE 'D%'
ORDER BY Name ASC
GO

--Task 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE HireDate > '2000-12-31'
GO

--Task 9
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5
GO

--Task 10
USE Geography
GO

SELECT CountryName, IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode ASC
GO

--Task 11
SELECT Peaks.PeakName, Rivers.RiverName, 
	LOWER(CONCAT(LEFT(Peaks.PeakName, LEN(Peaks.PeakName)-1), Rivers.RiverName)) AS Mix
FROM Peaks JOIN Rivers ON RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
ORDER BY Mix;
GO

--Task 12
USE Diablo
GO

SELECT TOP(50) Name, FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE [Start] BETWEEN '2011-01-01' AND '2012-12-31'
ORDER BY [Start] ASC, Name ASC
GO

--Task 13
SELECT Username, RIGHT(Email, CHARINDEX('@', REVERSE(Email)) - 1) AS [Email Provider]
FROM Users
ORDER BY [Email Provider] ASC, Username ASC
GO

--Task 14
SELECT Username, IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username
GO

--Task 15
SELECT Name, 
 CASE
  WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
  WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
  ELSE 'Evening'
 END AS [Part of the Day],
 CASE
  WHEN Duration <= 3 THEN 'Extra Short'
  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
  WHEN Duration > 6 THEN 'Long'
  ELSE 'Extra Long'
 END AS Duration
FROM Games
ORDER BY Name ASC, [Duration] ASC, [Part of the Day] ASC
GO

--Task 16
USE Orders
GO

SELECT ProductName, OrderDate, 
 DATEADD(DAY, 3, OrderDate) AS [Pay Due], 
 DATEADD(MONTH, 1, OrderDate) AS [Delivery Due]
FROM Orders
GO

--Task 17
CREATE DATABASE Test
GO

USE Test
GO

CREATE TABLE Test
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(30) NOT NULL,
	Birthdate DATETIME NOT NULL
)
GO

INSERT INTO Test
VALUES ('Pesho', '1990-02-03'),
	('Stamat', '1995-08-08'),
	('Gosho', '2015-07-11'),
	('Prakash', '1955-01-01'),
	('Stoyan', '1933-12-12')
GO

SELECT [Name], 
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age In Years], 
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age In Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age In Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age In Minutes]
FROM Test
GO


