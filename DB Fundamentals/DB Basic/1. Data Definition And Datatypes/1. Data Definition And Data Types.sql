--If you are going to submit these queries in SoftUni Judge system, remove GO tags.

--Task 1
CREATE DATABASE Minions
GO

USE Minions
GO

--Task 2
CREATE TABLE Minions
(
	Id INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Age  INT)
GO

CREATE TABLE Towns
(
    Id   INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL)
GO

--Task 3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
GO

--Task 4
INSERT INTO Towns(Id, Name)
VALUES (1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')
GO

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)
GO
	
--Task 5
TRUNCATE TABLE Minions
GO

--Task 6
DROP TABLE Minions
GO

DROP TABLE Towns
GO

--Task 7
CREATE TABLE People
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15,2),
	[Weight] DECIMAL(15,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)
)
GO

INSERT INTO People(Name, Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES ('Pesho', NULL, 150.2, 50.33, 'm', 1990-02-03, 'Pesho e nomer edno'),
	('Gosho', NULL, 160.2, 20.33, 'm', 1994-05-03, 'Gosho ot pochivka'),
	('StoyanLoshiqt', NULL, 170.2, 150.33, 'm', 199-04-08, '....'),
	('Prakash', NULL, 180.2, 5.33, 'm', 1990-02-03, 'Pesho pak e nomer edno'),
	('StoyanDobriqt', NULL, 190.2, 42350.33, 'm', 1864-10-03, 'Stoyan veche e nomer edno')
GO
		
--Task 8
CREATE TABLE Users
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)
GO

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES('Pesho', 'strongpassword123', 36, Null, 'true'),
	('Gosho', 'goshospassword', 1433, Null, 'false'),
	('Ivan', 'qkatarabota', 42352, Null, 'true'),
	('Tosho', 'neznamkakvopravq', 5236, Null, 'true'),
	('PeshoNomerDve', 'fasfgasf', 1, Null, 'false')
GO

--Task 9
ALTER TABLE Users 
DROP CONSTRAINT PK_Users
GO

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)
GO

--Task 10
ALTER TABLE Users
ADD CONSTRAINT [Password] CHECK(LEN(Password) >= 5)
GO

--Task 11
ALTER TABLE Users
ADD CONSTRAINT DF_Users DEFAULT GETDATE() FOR LastLoginTime
GO

--Task 12
ALTER TABLE Users DROP CONSTRAINT PK_Users
GO

ALTER TABLE Users
ADD CONSTRAINT PK_Person PRIMARY KEY(Id)
GO

ALTER TABLE Users
ADD CONSTRAINT UC_Users UNIQUE(Username)
GO

ALTER TABLE Users
ADD CONSTRAINT CHK_Users CHECK(LEN(Password) >= 3)
GO

--Task 13
CREATE DATABASE Movies
GO

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DirectorName NVARCHAR(255) NOT NULL,
	Notes NVARCHAR(255)
)
GO

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	GenreName NVARCHAR(255) NOT NULL,
	Notes NVARCHAR(255)
)
GO

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName NVARCHAR(255) NOT NULL,
	Notes NVARCHAR(255)
)
GO

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY(1,1),	
	Title NVARCHAR(255) NOT NULL,
	DirectorID INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE,
	Length DECIMAL(10,2),
	GenreID INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryID INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating INT,
	Notes NVARCHAR(255)
)
GO

INSERT INTO Directors(DirectorName, Notes) 
VALUES('Pesho', 'bezdelnik'),
	('Stamat', 'tepence'),
	('GoshU', 'ailqche'),
	('Gocho', 'bratok'),
	('Stoyan', 'trrr')
GO

INSERT INTO Genres(GenreName, Notes) 
VALUES('Horror', NULL),
	('Comedy', NULL),
	('ne', NULL),
	('znam', NULL),
	('janrove', NULL)
GO

INSERT INTO Categories(CategoryName, Notes) 
VALUES('po vreme na rabota', NULL),
	('po vreme na lekcii', NULL),
	('kibik', NULL),
	('murzel', NULL),
	('sarma v mraka', NULL)
GO

INSERT INTO Movies(Title, DirectorID, CopyrightYear, Length, GenreID, CategoryID,Rating,Notes) 
VALUES('Kokoshkata s plombiraniq zub', 1, NULL, NUll, 1, 3, 5,NULL),
	('Gorski reket', 2, NULL, NUll, 3, 2, 4,NULL),
	('Rado shisharkata', 4, NULL, NUll, 4, 1, 3,NULL),
	('Hisarskia pop', 3, NULL, NUll, 5, 4, 2,NULL),
	('Valdes', 5, NULL, NUll, 2, 1, 1,NULL)
GO

--Task 14
CREATE DATABASE CarRental
GO

USE CarRental
GO

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT NOT NULL,
	WeekendRate INT
)
GO

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Platenumber NVARCHAR(50) NOT NULL UNIQUE,
	Model NVARCHAR(255) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId NVARCHAR(255),
	Doors INT,
	Picture NTEXT,
	Condition NVARCHAR(50) NOT NULL,
	Available INT NOT NULL
)
GO

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(255) NOT NULL,
	Notes NVARCHAR(255)
)
GO

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DriverLicenceNumber INT NOT NULL UNIQUE,
	FullName NVARCHAR(255) NOT NULL,
	[Address] NVARCHAR(255),
	City NVARCHAR(255) NOT NULL,
	ZIPCode NVARCHAR(255),
	Notes NVARCHAR(255)
)
GO

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT UNIQUE NOT NULL,
	CustomerId INT UNIQUE NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied NVARCHAR(50),
	TaxRate NVARCHAR(50),
	OrderStatus NVARCHAR(255),
	Notes NVARCHAR(255)
)
GO

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) 
VALUES('Sedan', NULL, 3, 100, 2),
	('Coupet', 1, NULL, 900, NULL),
	('Jeep', 4, 5, 800, 35)
GO

INSERT INTO Cars(Platenumber, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) 
VALUES('PB 1488 АС', 'BMW', 2017, NULL,4,NULL,'New', 10),
	('PB 1111 CA', 'AUDI', 2017, NULL,2,NULL,'New', 21),
	('PB 4444 GA', 'MERCEDES', 2017, NULL,4,NULL,'New', 9)
GO

INSERT INTO Employees(FirstName, LastName, Title, Notes) 
VALUES('Pesho','Peshov','Trrrr', NULL),
	('Gosho','Goshov','...', NULL),
	('Stamat','Stamatov','cccc', NULL)
GO

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) 
VALUES(5821596,'Stamat Stamatov Stamatov',NULL,'Sofia', NULL, NULL),
	(123513,'Prakash Prakashov Prakashki',NULL,'England', 'TN9T4U', NULL),
	(09834758,'Softuni Softuniadov',NULL,'Switzerland', NULL, NULL)
GO

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) 
VALUES(5315351, 1351, 5, NULL, 5000, 2351, 1231245, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(53453, 643, 3, NULL, 567876, 12323, 3453453, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(7859647, 123, 2, NULL, 12312, 543536, 367787, NULL, NULL, NULL, NULL, NULL, 'DELIVERED', NULL)
GO

--Task 15
CREATE DATABASE Hotel
GO

USE Hotel
GO

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30),
	Title NVARCHAR(30),
	Notes NVARCHAR(max)
)
GO

CREATE TABLE Customers
(
	AccountNumber INT,
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30),
	PhoneNumber INT,
	EmergencyName NVARCHAR(30),
	EmergencyNumber INT,
	Notes NVARCHAR(max)
)
GO

CREATE TABLE RoomStatus
(
	Id INT PRIMARY KEY,
	RoomStatus NVARCHAR(20),
	Notes NVARCHAR(max)
)
GO

CREATE TABLE RoomTypes
(
	Id INT PRIMARY KEY,
	RoomTypes NVARCHAR(20),
	Notes NVARCHAR(max)
)
GO

CREATE TABLE BedTypes
(
	Id INT PRIMARY KEY,
	BedTypes NVARCHAR(20),
	Notes NVARCHAR(max)
)
GO

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(Id),
	BedType INT FOREIGN KEY REFERENCES BedTypes(Id),
	Rate INT,
	RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(Id),
	Notes NVARCHAR(max)
)
GO

CREATE TABLE Payments
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME,
	AccountNumber INT,
	FirstDateOccupied DATETIME,
	LastDateOccupied DATETIME,
	TotalDays INT,
	AmountCharged DECIMAL(10,2),
	TaxRate DECIMAL(10,2),
	TaxAmount DECIMAL(10,2),
	PaymentTotal DECIMAL(10,2),
	Notes NVARCHAR(max)
)
GO

CREATE TABLE Occupancies
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME,
	AccountNumber INT,
	RoomNumber INT,
	RateApplied DECIMAL(10,2),
	PhoneCharge DECIMAL(10,2),
	Notes NVARCHAR(max)
)
GO

INSERT INTO Employees 
VALUES('Pesho', 'Peshov', 'Bartender', NULL),
	('Gosho', 'Goshov', 'Chef', NULL),
	('Prakash', 'Stamatov', 'Bartender', NULL)
GO

INSERT INTO Customers 
VALUES(1, 'Stoyannnnn', 'Stoenchev', 088701, NULL, 089522408, null),
	(2, 'Gosho', 'Peshov', 51410701,NULL, 083395408, null),
	(3, 'Tosho', 'Goshov', 00098701, NULL, 01895408, null)
GO

INSERT INTO RoomStatus 
VALUES(1,'Available', NULL),
	(2,'Vacated', NULL),
	(3,'Dirty', NULL)
GO

INSERT INTO RoomTypes 
VALUES(1,'King Suite', NULL),
	(2,'Queen Suite', NULL),
	(3,'Prince Suite', NULL)
GO

INSERT INTO BedTypes 
VALUES(1,'Small', NULL),
	(2,'Not so big', NULL),
	(3,'Big', NULL)
GO

INSERT INTO Rooms 
VALUES(123, 1 ,null, 80, 1, NULL),
	(432, 2 ,null, 80, 1, NULL),
	(333, 3,null, 80, 1, NULL)
GO

INSERT INTO Payments 
VALUES(1, NULL, 1, NULL, NULL, 80, 414, 4312, 124, 23, NULL),
	(2, NULL, 3, NULL, NULL, 80, 414, 4312, 124, 23, NULL),
	(3, NULL, 2, NULL, NULL, 80, 414, 4312, 124, 23, NULL)
GO

INSERT INTO Occupancies 
VALUES(1, NULL, 3, 123, 321, 33, NULL),
	(2, NULL, 1, 123, 321, 33, NULL),
	(3, NULL, 2, 123, 321, 33, NULL)
GO

--Task 16
CREATE DATABASE SoftUni
GO

USE SoftUni
GO

CREATE TABLE Towns
(
	Id   INT
	PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Addresses
(
	Id          INT
	PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(100) NOT NULL,
	TownId      INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)
GO

CREATE TABLE Departments
(
	Id     INT
	PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Employees
(
	Id           INT
	PRIMARY KEY IDENTITY NOT NULL,
	FirstName    NVARCHAR(50) NOT NULL,
	MiddleName   NVARCHAR(50),
	LastName     NVARCHAR(50),
	JobTitle     NVARCHAR(100) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate     DATE,
	Salary       DECIMAL(10, 2) NOT NULL,
	AddressId    INT FOREIGN KEY REFERENCES Addresses(Id)
)
GO

--Task 17
BACKUP DATABASE SoftUni TO DISK = 'D:\softuni-backup.bak'

USE CarRental

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'D:\softuni-backup.bak'

--Task 18
USE SoftUni
GO

INSERT INTO Towns(Name)
VALUES('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')
GO

INSERT INTO Departments(Name)
VALUES('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')
GO

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(DATE, '02/03/2004', 103), 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(DATE, '05/08/2011', 103), 4000.00),
	('Maria', 'Ivanova', 'Petrova', 'Intern', 5, CONVERT(DATE, '09/07/2015', 103), 500.00),
	('Shaban', 'Qso', 'Shaulich', 'Singer', 2, CONVERT(DATE, '11/11/1800', 103), 5235236.00),
	('Mile', 'Qso', 'Kitich', 'Pevec', 8, CONVERT(DATE, '03/12/1950', 103), 324234.00)
GO

		
--Task 19
SELECT *
FROM Towns
GO

SELECT *
FROM Departments
GO

SELECT *
FROM Employees
GO

--Task 20
SELECT *
FROM Towns
ORDER BY Name ASC
GO

SELECT *
FROM Departments
ORDER BY Name ASC
GO

SELECT *
FROM Employees
ORDER BY Salary DESC
GO

--Task 21
SELECT [Name]
FROM Towns
ORDER BY [Name] ASC
GO

SELECT [Name]
FROM Departments
ORDER BY [Name] ASC
GO

SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM Employees
ORDER BY Salary DESC

--Task 22
UPDATE Employees
SET Salary *= 1.10
GO

SELECT [Salary]
FROM Employees
GO

--Task 23
USE Hotel

UPDATE Payments
SET TaxRate -= TaxRate * 3 / 100
GO

SELECT TaxRate 
FROM Payments
GO

--Task 24
TRUNCATE TABLE Occupancies;
GO