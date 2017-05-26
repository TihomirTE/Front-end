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
		e.DepartmentID
FROM Employees e
WHERE e.Salary =
	(SELECT MIN(Salary) FROM Employees em
	 WHERE em.DepartmentID = e.DepartmentID)
ORDER BY e.DepartmentID

-- Task 4
SELECT 
	AVG(Salary) AS [Average Salary]
FROM Employees
WHERE DepartmentID = 1

-- Task 5
SELECT 
	AVG(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales' 

-- Task 6
SELECT COUNT(*) 
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'

-- Task 7
SELECT COUNT(*) [¹ of employees with manager]
FROM Employees e
	-- Variant 1
	WHERE e.ManagerID IS NOT NULL
	-- Variant 2
	--JOIN Employees m
		--ON m.EmployeeID = e.ManagerID

-- Task 8
SELECT COUNT(*) AS [¹ of employees with manager]
FROM Employees e
	WHERE e.ManagerID IS NULL

-- Task 9
SELECT 
	d.Name,
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