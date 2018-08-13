--If you are going to submit these queries in SoftUni Judge system, remove GO tags.

--Task 1
CREATE DATABASE TableRelations
GO

USE TableRelations
GO

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY,
	FirstName VARCHAR(50),
	Salary decimal,
	PassportID INT UNIQUE
)
CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber NVARCHAR(255)
)

INSERT INTO Passports 
VALUES (101, 'N34FG21B'), 
  (102, 'K65LO4R7'), 
  (103, 'ZE657QP2')

INSERT INTO Persons 
VALUES (1, 'Pesho', 43330.00, 102),
  (2, 'Gosho', 56100.00, 103),
  (3, 'Stamat', 60200.00, 101)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
GO

--Task 2
CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
	Name NVARCHAR(50),
	ManufacturerID INT
)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY,
	Name NVARCHAR(50),
	EstablishedOn DATE
)

INSERT INTO Manufacturers 
VALUES(1, 'Mercedes', '07/03/1926'),
	(2, 'Trabant', '01/01/2018'),
	(3, 'Lada', '01/05/2035')

INSERT INTO Models 
VALUES(101, 'C', 1),
	(102, 'S', 1),
	(103, 'AA', 2),
	(104, 'asdg', 2),
	(105, 'fasg', 2),
	(106, 'grrr', 3)

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
GO

--Task 3
CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	Name NVARCHAR(50)
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	Name NVARCHAR(255)
)

CREATE TABLE StudentsExams(
	StudentID INT,
	ExamID INT,
	
	CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_ExamID FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students 
VALUES(1, 'Pesho'),
	(2, 'Stamat'),
	(3, 'Gosho')

INSERT INTO Exams 
VALUES(101, 'HAHAHAHA'),
	(102, 'AAAAAAAAA'),
	(103, 'BBBBBB')

INSERT INTO StudentsExams 
VALUES(1, 101), 
  (1, 102), 
  (2, 101), 
  (3, 103), 
  (2, 102), 
  (2, 103)
GO

--Task 4
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	Name NVARCHAR(255),
	ManagerID INT,
	
	CONSTRAINT FK_ManagerID_TeacherID FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers 
VALUES(101, 'Stoyan', NULL),
  (102, 'Ivan', 106),
  (103, 'Dragan', 106),
  (104, 'Petkan', 105),
  (105, 'Stamatkan', 101),
  (106, 'Shmatkan', 101)
GO

--Task 5
CREATE TABLE Cities(
  CityID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Customers(
  CustomerID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  Birthday DATE,
  CityID INT,
  
  CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
  OrderID INT PRIMARY KEY,
  CustomerID INT NOT NULL,
  
  CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
  ItemTypeID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Items(
  ItemID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  ItemTypeID INT NOT NULL,
  
  CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
  OrderID INT NOT NULL,
  ItemID INT NOT NULL,
  
  CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID),
  CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)
GO

--Task 6
CREATE TABLE Majors(
  MajorID INT PRIMARY KEY,
  Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Students(
  StudentID INT PRIMARY KEY,
  StudentNumber INT NOT NULL UNIQUE,
  StudentName NVARCHAR(200) NOT NULL,
  MajorID INT,
  
  CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)


CREATE TABLE Payments(
  PaymentID INT PRIMARY KEY,
  PaymentDate DATE NOT NULL,
  PaymentAmount MONEY NOT NULL,
  StudentID INT NOT NULL,
  
  CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
  SubjectID INT PRIMARY KEY,
  SubjectName NVARCHAR(50) NOT NULL,
)

CREATE TABLE Agenda(
  StudentID INT NOT NULL,
  SubjectID INT NOT NULL,
  
  CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
  CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
  CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)
GO

--Task 9
Use Geography
GO

SELECT MountainRange, PeakName, Elevation
FROM Peaks AS p 
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC
GO