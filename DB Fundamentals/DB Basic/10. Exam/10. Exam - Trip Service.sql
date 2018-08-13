CREATE DATABASE TripService
GO

USE TripService
GO

--Task 1
CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(14,2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(14,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	ReturnDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	BookDate DATE NOT NULL,
	CancelDate DATE,

	CONSTRAINT CHK_ArrivalDate CHECK(ArrivalDate < ReturnDate),
	CONSTRAINT CHK_BookDate CHECK(BookDate < ArrivalDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL

	CONSTRAINT PK_AccountsTrips PRIMARY KEY(AccountId, TripId)
)

--Task 2
INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
	('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
	('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
	(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
	(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
	(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--Task 3
UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN (5,7,9)

--Task 4
DELETE FROM AccountsTrips
WHERE AccountId = 47

--Task 5
SELECT Id, [Name]
FROM Cities
WHERE CountryCode = 'BG'
ORDER BY [Name]

--Task 6
SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name], 
	YEAR(BirthDate) AS [BirthYear]
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY [BirthYear] DESC, FirstName

--Task 7
SELECT a.FirstName, 
	a.LastName, 
	FORMAT(a.BirthDate, 'MM-dd-yyyy') AS [BirthDate], 
	c.[Name] AS [Hometown],
	a.Email
FROM Accounts AS a
JOIN Cities AS c
ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.[Name] DESC

--Task 8
SELECT c.[Name] AS [City], COUNT(h.Id) AS [Hotels]
FROM Cities AS c
LEFT JOIN Hotels AS h
ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY [Hotels] DESC, c.[Name]

--Task 9
SELECT r.Id, 
	r.Price, 
	h.[Name] AS [Hotel], 
	c.[Name] AS [City]
FROM Rooms AS r
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
WHERE r.[Type] = 'First Class'
ORDER BY r.Price DESC, r.Id

--Task 10
SELECT a.Id,
	CONCAT(a.FirstName, ' ', a.LastName) AS [FullName],
	MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [LongestTrip],
	MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS at
ON [at].AccountId = a.Id
JOIN Trips AS t
ON t.Id = [at].TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY [LongestTrip] DESC, a.Id

--Task 11
SELECT TOP(5) c.Id,
	c.[Name],
	c.CountryCode AS [Country],
	COUNT(a.Id) AS [Accounts]
FROM Cities AS c
JOIN Accounts AS a
ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY [Accounts] DESC

--Task 12
SELECT a.Id, 
	a.Email,
	c.[Name] AS [City],
	COUNT(t.Id) AS [Trips]
FROM Accounts AS a
JOIN AccountsTrips AS [at]
ON [at].AccountId = a.Id
JOIN Trips AS t
ON t.Id = [at].TripId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY [Trips] DESC, a.Id

--Task 13
SELECT TOP(10) c.Id, 
	c.[Name],
	SUM(h.BaseRate + r.Price) AS [Total Revenue],
	COUNT(t.Id) AS [Trips]
FROM Cities AS c
JOIN Hotels AS h
ON h.CityId = c.Id
JOIN Rooms AS r
ON r.HotelId = h.Id
JOIN Trips AS t
ON t.RoomId = r.Id
WHERE YEAR(t.BookDate) = 2016
GROUP BY c.Id, c.[Name]
ORDER BY [Total Revenue] DESC, [Trips] DESC

--Task 14
SELECT t.Id,
	h.[Name] AS [HotelName],
	r.[Type] AS [RoomType],
	CASE
		WHEN t.CancelDate IS NULL THEN (h.BaseRate + r.Price)
		ELSE 0
	END AS [Revenue]
FROM Trips AS t
JOIN AccountsTrips AS [at]
ON [at].TripId = t.Id
JOIN Accounts AS a
ON a.Id = [at].AccountId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
GROUP BY t.id, h.[Name], r.[Type], t.CancelDate, h.BaseRate, r.Price
ORDER BY [RoomType], t.Id

--Task 15
SELECT t.Id, t.Email, t.CountryCode, t.Trips
FROM(SELECT a.Id, 
		a.Email,
		c.CountryCode,
		COUNT(t.Id) AS [Trips],
		ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC) AS AccountsRank
	FROM Accounts AS a
	JOIN AccountsTrips AS [at]
	ON [at].AccountId = a.Id
	JOIN Trips AS t
	ON t.Id = [at].TripId
	JOIN Rooms AS r
	ON r.Id = t.RoomId
	JOIN Hotels AS h
	ON h.Id = r.HotelId
	JOIN Cities AS c
	ON c.Id = h.CityId
	GROUP BY a.Id, a.Email, c.CountryCode
) AS t
WHERE AccountsRank = 1
ORDER BY t.Trips DESC, t.Id

--Task 16
SELECT t.Id,
	SUM([at].Luggage),
	CASE
		WHEN SUM([at].Luggage) > 5 THEN CONCAT('$', SUM([at].Luggage) * 5)
		ELSE '$0'
	END AS [Fee]
FROM Trips AS t
JOIN AccountsTrips AS [at]
ON [at].TripId = t.Id
WHERE [at].Luggage > 0
GROUP BY t.Id
ORDER BY SUM([at].Luggage) DESC

--Task 17
SELECT t.Id,
	CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS [Full Name], 
	(SELECT c.[Name] 
		FROM Cities AS c
		WHERE c.Id = a.CityId) AS [From],
	(SELECT c.[Name] WHERE c.Id = h.CityId) AS [To],
	CASE
		WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		ELSE 'Canceled'
	END AS [Duration]
FROM Accounts AS a
JOIN AccountsTrips AS [at]
ON [at].AccountId = a.Id
JOIN Trips AS t
ON t.Id = [at].TripId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
ORDER BY [Full Name], t.Id

--Task 18
GO
CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @roomId INT = (SELECT TOP(1) r.Id
		FROM Rooms AS r
		JOIN Trips AS t
		ON t.RoomId = r.Id
		WHERE r.HotelId = @HotelId
			AND r.Beds >= @People
			AND (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
			OR @Date BETWEEN t.ArrivalDate AND t.ReturnDate AND t.CancelDate IS NOT NULL)
		GROUP BY r.Id, r.Price
		ORDER BY r.Price DESC)

	IF (@roomId IS NULL)
	BEGIN
		RETURN 'No rooms available'
	END

	DECLARE @roomPrice DECIMAL(14,2) = (SELECT r.Price FROM Rooms AS r WHERE r.Id = @roomId)
	DECLARE @hotelBaseRate DECIMAL(14,2) = (SELECT h.BaseRate FROM Hotels AS h WHERE h.Id = @HotelId)
	DECLARE @roomType NVARCHAR(20) = (SELECT r.[Type] FROM Rooms AS r WHERE r.Id = @roomId)
	DECLARE @roomBeds INT = (SELECT r.Beds FROM Rooms AS r WHERE r.Id = @roomId)
	DECLARE @price DECIMAL(14,2) = (SELECT (@roomPrice + @hotelBaseRate) * @People)

	RETURN CONCAT('Room ', @roomId, ': ', @roomType, ' (', @roomBeds, ' beds) - $', @price) 
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

SELECT *
FROM Rooms
WHERE Id = 175



--Task 19
GO
CREATE OR ALTER PROCEDURE usp_SwitchRoom @TripId INT, @TargetRoomId INT
AS
BEGIN
	BEGIN TRANSACTION

	DECLARE @hotelId INT = (SELECT h.Id
		FROM Hotels AS h
		JOIN Rooms AS r
		ON r.HotelId = h.Id
		JOIN Trips AS t
		ON t.RoomId = r.Id
		WHERE t.Id = @TripId)
	
	DECLARE @targetHotelId INT = (SELECT h.Id
		FROM Hotels AS h
		JOIN Rooms AS r
		ON r.HotelId = h.Id
		WHERE r.Id = @TargetRoomId)
	
	IF (@hotelId <> @targetHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!', 16, 1)
	END
	
	DECLARE @targetRoomBeds INT = (SELECT r.Beds
		FROM Rooms AS r
		WHERE r.Id = @TargetRoomId)
	
	DECLARE @tripPeople INT = (SELECT COUNT(a.Id)
		FROM Accounts AS a
		JOIN AccountsTrips AS [at]
		ON [at].AccountId = a.Id
		JOIN Trips AS t
		ON t.Id = [at].TripId
		WHERE t.Id = @TripId)
	
	IF (@targetRoomBeds < @tripPeople)
	BEGIN
		RAISERROR('Not enough beds in target room!', 16, 1)
	END
	
	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
	
	COMMIT
END
GO

--Task 20
GO
CREATE OR ALTER TRIGGER tr_CancelTrips ON Trips 
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE CancelDate IS NULL 
		AND Id IN (SELECT Id FROM deleted)
END

DELETE FROM Trips
WHERE Id IN (48, 49, 50)
