USE TelerikAcademy

-- Task 1
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
		e.Salary
	FROM Employees e
		WHERE e.Salary = 
			(SELECT MIN(Salary) FROM Employees)

-- Task 2
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
		e.Salary
	FROM Employees e
		WHERE e.Salary <= 
			(SELECT MIN(Salary) * 1.1 FROM Employees)
	ORDER BY e.Salary

-- Task 3
SELECT e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName AS [Employee],
		e.Salary,
		d.Name AS [Department]
	FROM Employees e	
	 JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
		WHERE e.Salary =
			(SELECT MIN(Salary) FROM Employees em
				WHERE em.DepartmentID = e.DepartmentID)
	ORDER BY d.Name

-- Task 4
SELECT 
	AVG(Salary) AS [Average Salary],
	d.Name AS [Department]
	FROM Employees e
		JOIN Departments d
			ON d.DepartmentID = e.DepartmentID
	WHERE e.DepartmentID = 1
	GROUP BY d.Name

-- Task 5
SELECT 
	AVG(Salary) AS [Average Salary],
	d.Name AS [Department]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales' 
	GROUP BY d.Name

-- Task 6
SELECT COUNT(*) AS [Employees number],
	d.Name AS [Department]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name

-- Task 7
SELECT COUNT(*) [Employees with manager]
FROM Employees e
	-- Variant 1
	WHERE e.ManagerID IS NOT NULL
	-- Variant 2
	--JOIN Employees m
		--ON m.EmployeeID = e.ManagerID

-- Task 8
SELECT COUNT(*) AS [Employees without manager]
FROM Employees e
	WHERE e.ManagerID IS NULL

-- Task 9
SELECT 
	d.Name AS [Department],
	AVG(e.Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

-- Task 10
SELECT 
	d.Name AS [Department],
	t.Name AS [Town],
	COUNT(e.EmployeeID) AS [Employees number]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY d.Name, t.Name

-- Task 11
SELECT
	m.FirstName, m.LastName
FROM Employees e
	JOIN Employees m
		ON m.EmployeeID = e.ManagerID
	GROUP BY m.FirstName, m.LastName
	HAVING COUNT(*) = 5

-- Task 12
SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON m.EmployeeID = e.ManagerID
	
-- Task 13
SELECT
	FirstName, LastName
FROM Employees
	WHERE LEN(LastName) = 5

-- Task 14
SELECT FORMAT(GETDATE(), 'dd.MMM.yyyy hh:m:ss:fff') AS [Date&Time]

-- Task 15
CREATE TABLE Users 
(
	[Id] INT IDENTITY PRIMARY KEY NOT NULL,
	[Username] NVARCHAR(50) UNIQUE NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[UserPassword] NVARCHAR(50) CHECK(LEN(UserPassword) >= 5) NOT NULL,
	[LastLogin] smalldatetime
)

-- Task 16

CREATE VIEW TodayVisitors AS
	SELECT LastLogin FROM Users
	WHERE CONVERT(DATE, LastLogin) = CONVERT(DATE,GETDATE())

-- Task 17
CREATE TABLE Groups (
	[Id] INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
)

-- Task 18
ALTER TABLE Users
	ADD GroupId INT
	GO
ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupId)
	REFERENCES Groups(Id)
	GO

-- Task 19
INSERT INTO Groups
	VALUES
	('Group 1'),
	('Group 2'),
	('Group 3')

INSERT INTO Users
	VALUES
	('User1', 'Gosho1', '12345', GETDATE(), 2),
	('User2', 'Gosho2', '54321', GETDATE(), 1),
	('User3', 'Gosho3', '67890', GETDATE(), 2),
	('User4', 'Gosho4', '09876', GETDATE(), 3)

-- Task 20
UPDATE Users
	SET LastLogin = GETDATE()
FROM Users
	WHERE Username = 'Pesho'

UPDATE Groups
	SET Name = 'Group 5'
	WHERE Id = 1

-- Task 21
DELETE FROM Users
	WHERE Username = 'Gosho'

-- Task 22
INSERT INTO Users(Username, FullName, UserPassword, LastLogin, GroupId)
	SELECT SUBSTRING(FirstName, 0, 1) + LOWER(LastName),
			FirstName + ' ' + LastName,
			SUBSTRING(FirstName, 0, 1) + LOWER(LastName) + 'password',
			NULL,
			2
	FROM Employees

-- Task 23
ALTER TABLE Users
ALTER COLUMN UserPassword nvarchar(50) NULL

UPDATE Users
	SET UserPassword = NULL
FROM Users
	WHERE LastLogin <= CONVERT(smalldatetime, '2017-05-27 15:16:00')

-- Task 24
DELETE FROM Users
	WHERE UserPassword IS NULL

-- Task 25
SELECT  e.JobTitle,
		d.Name AS [Department],
		AVG(e.Salary) AS [AVG Salary]
	FROM Employees e
		JOIN Departments d
			ON d.DepartmentID = e.DepartmentID
	GROUP BY e.JobTitle, d.Name

-- Task 26
SELECT  e.FirstName + ' ' + e.LastName AS [Employee],
		e.JobTitle,
		d.Name AS [Department],
		MIN(e.Salary) AS [Min Salary]
	FROM Employees e
		JOIN Departments d
			ON d.DepartmentID = e.DepartmentID
	GROUP BY e.JobTitle, d.Name, e.FirstName, e.LastName
	ORDER BY d.Name

-- Task 27
SELECT TOP(1) t.Name AS [Town],
		COUNT(*) AS [Employees number]
	FROM Employees e
		JOIN Addresses a
			ON a.AddressID = e.AddressID
		JOIN Towns t
			ON t.TownID = a.TownID
	GROUP BY t.Name
	ORDER BY [Employees number] DESC

-- Task 28
SELECT t.Name AS [Town],
		COUNT(DISTINCT e.ManagerID) AS [Managers number]
	FROM Employees e
		JOIN Addresses a
			ON a.AddressID = e.AddressID
		JOIN Towns t
			ON t.TownID = a.TownID
	GROUP BY t.Name
	ORDER BY [Managers number]

-- Task 29
CREATE TABLE WorkHours
(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY(EmployeeId) REFERENCES Employees(EmployeeID) NOT NULL,
	[Date] DATETIME,
	[Task] NVARCHAR(50),
	[Hours] INT,
	[Comments] VARCHAR(200)
)
GO

INSERT INTO WorkHours
	VALUES
		(1, GETDATE(), 'Database', 20, 'Write SQL'),
		(2, GETDATE(), 'Refactoring', 50, 'Legacy code'),
		(3, GETDATE(), 'Unit tests', 70, '100% code coverage')
GO

UPDATE WorkHours
	SET Comments = 'Relational Database'
	WHERE EmployeeId = 1
 GO

DELETE FROM WorkHours
	WHERE Task = 'Unit tests'
GO

CREATE TABLE ReportsLogs
(
	[Id]  INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[Date] DATETIME,
	[Task] NVARCHAR(50),
	[Hours] INT,
	[Comments] VARCHAR(200),
	[For] VARCHAR(50)
)
GO

-- Triggers
CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
	FOR INSERT
	AS
	INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
			SELECT [EmployeeId], [Date], [Task], [Hours], [Comments],
			'INSERT'
			FROM INSERTED
GO

CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
	FOR DELETE 
	AS
	INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
		SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 
		'DELETE'
		FROM DELETED
GO

CREATE TRIGGER trg_WorkHours_Update ON WorkHours
	FOR UPDATE 
	AS
	INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
		SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 
		'UPDATE'
		FROM INSERTED
GO

-- Changes
INSERT INTO WorkHours
	VALUES(2, GETDATE(), 'Unit tests', 35, '100% code coverage')
GO

INSERT INTO WorkHours
	VALUES(3, GETDATE(), 'Refactoring', 50, 'Legacy code')
GO

DELETE FROM  WorkHours 
	WHERE Id = 5
GO

UPDATE WorkHours
	SET Comments = '90% code coverage'
	WHERE Task = 'Unit tests'


-- Task 30
