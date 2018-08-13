CREATE DATABASE WMS
GO

USE WMS
GO

--Task 1
CREATE TABLE Clients(
	ClientId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics(
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models(
	ModelId INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs(
	JobId INT PRIMARY KEY IDENTITY NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) CHECK([Status] IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending',
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders(
	OrderId INT PRIMARY KEY IDENTITY NOT NULL,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors(
	VendorId INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts(
	PartId INT PRIMARY KEY IDENTITY NOT NULL,
	SerialNumber VARCHAR(50) UNIQUE,
	[Description] VARCHAR(255),
	Price DECIMAL(6,2) CHECK(Price > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity > 0)  DEFAULT 1 

	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1

	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

--Task 2
INSERT INTO Clients(FirstName, LastName, Phone)
VALUES ('Teri', 'Ennaco', '570-889-5187'),
	('Merlyn', 'Lawler', '201-588-7810'),
	('Georgene', 'Montezuma', '925-615-5185'),
	('Jettie', 'Mconnell', '908-802-3564'),
	('Lemuel', 'Latzke', '631-748-6479'),
	('Melodie', 'Knipp', '805-690-1682'),
	('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId)
VALUES ('WP8182119', 'Door Boot Seal', 117.86, 2),
	('W10780048', 'Suspension Rod', 42.81, 1),
	('W10841140', 'Silicone Adhesive', 6.77, 4),
	('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--Task 3
UPDATE Jobs
SET [Status] = 'In Progress', MechanicId = 3
WHERE [Status] = 'Pending'

--Task 4
DELETE FROM OrderParts 
WHERE OrderId = 19

DELETE FROM Orders 
WHERE OrderId = 19

--Task 5
SELECT FirstName, LastName, Phone
FROM Clients
ORDER BY LastName, ClientId

--Task 6
SELECT [Status], IssueDate
FROM Jobs
WHERE [Status] <> 'Finished'
ORDER BY IssueDate, JobId

--Task 7
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, j.[Status], j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--Task 8
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	j.[Status]
FROM Clients AS c
JOIN Jobs AS j
ON j.ClientId = c.ClientId
WHERE j.[Status] <> 'Finished'
ORDER BY [Days going] DESC, c.ClientId

--Task 9
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), j.[Status], m.MechanicId
HAVING j.[Status] = 'Finished'
ORDER BY m.MechanicId

--Task 10
SELECT TOP(3) CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, COUNT(j.JobId) AS Jobs
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), j.[Status], m.MechanicId
HAVING j.[Status] <> 'Finished' AND COUNT(j.JobId) > 1
ORDER BY Jobs DESC, m.MechanicId

--Task 11
SELECT [Name] AS Available 
FROM(SELECT MechanicId, CONCAT(FirstName, ' ', LastName) as [Name] 
	FROM Mechanics
	WHERE MechanicId 
		NOT IN (SELECT MechanicId FROM Jobs WHERE Status <> 'Finished' AND MechanicId IS NOT NULL)
) AS e
ORDER BY MechanicId

--Task 12
SELECT ISNULL(SUM(p.Price * op.Quantity),0) AS [Parts Total]
FROM Orders AS o
JOIN OrderParts AS op
ON op.OrderId = o.OrderId
JOIN Parts AS p
ON p.PartId = op.PartId
WHERE DATEDIFF(WEEK, o.IssueDate, '2017-04-24') <= 3

--Task 13
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity),0) AS [Total]
FROM Jobs as j
FULL JOIN Orders as o ON o.JobId = j.JobId
FULL JOIN OrderParts as op ON op.OrderId = o.OrderId
FULL JOIN Parts as p ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY [Total] DESC, j.JobId

--Task 14
SELECT m.ModelId, 
	m.[Name], 
	CONCAT(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)), ' days') AS [Average Service Time]
FROM Models AS m
JOIN Jobs AS j
ON j.ModelId = m.ModelId
WHERE j.FinishDate IS NOT NULL
GROUP BY m.ModelId, m.[Name]
ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))

--Task 15
SELECT TOP 1 WITH TIES m.Name, 
	COUNT(j.JobId) AS [Times Serviced],
    (SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
	  FROM Orders AS o
	  JOIN OrderParts AS op 
	  ON op.OrderId = o.OrderId
	  JOIN Parts AS p 
	  ON p.PartId = op.PartId
	  JOIN Jobs AS j 
	  ON j.JobId = o.JobId
	  WHERE j.ModelId = m.ModelId
) AS [Parts Total]
FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.Name, m.ModelId
ORDER BY [Times Serviced] DESC

--Task 16
   SELECT p.PartId,
          p.[Description],
          SUM(pn.Quantity) AS [Required],
          SUM(p.StockQty) AS [In Stock],
          ISNULL(SUM(op.Quantity),0) AS [Ordered]
     FROM Parts AS p
     JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
     JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
   WHERE j.[Status] <> 'Finished'
GROUP BY p.PartId, p.[Description]
  HAVING SUM(pn.Quantity) > SUM(p.StockQty) + ISNULL(SUM(op.Quantity),0)
ORDER BY p.PartId

--Task 17