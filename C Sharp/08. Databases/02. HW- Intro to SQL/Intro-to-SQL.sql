USE TelerikAcademy

-- Task 4
SELECT * FROM Departments

-- Task 5
SELECT Name FROM Departments

-- Task 6
SELECT FirstName + ' ' + LastName AS [Employee], Salary 
	FROM Employees

-- Task 7
SELECT FirstName + ' ' + LastName + ' ' + MiddleName AS [FullName] 
	FROM Employees
		WHERE MiddleName IS NOT NULL

-- Task 8
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]  
	FROM Employees

-- Task 9
SELECT DISTINCT Salary 
	FROM Employees

-- Task 10
SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative'

-- Task 11
SELECT FirstName 
	FROM Employees
		WHERE FirstName LIKE 'SA%'

-- Task 12
SELECT LastName 
	FROM Employees
		WHERE LastName LIKE '%ei%'

-- Task 13
SELECT FirstName + ' ' + LastName AS [Employee], Salary 
	FROM Employees
		WHERE Salary BETWEEN 20000 AND 30000
	ORDER BY Salary

-- Task 14
SELECT FirstName + ' ' + LastName AS [Employee], Salary 
	FROM Employees
		WHERE Salary IN (25000, 14000, 12500, 23600)
	ORDER BY Salary

-- Task 15
SELECT * FROM Employees
	WHERE ManagerID IS NULL

-- Task 16
SELECT FirstName + ' ' + LastName AS [Employee], Salary 
	FROM Employees
		WHERE Salary > 50000
	ORDER BY Salary DESC

-- Task 17
SELECT TOP(5) FirstName + ' ' + LastName AS Employee, Salary 
	FROM Employees    
	ORDER BY Salary DESC  

-- Task 18
SELECT e.FirstName + ' ' + e.LastName AS [Employee], a.AddressText AS [Address] 
	FROM Employees e
		INNER JOIN Addresses a
			ON a.AddressID = e.AddressID

-- Task 19
SELECT e.FirstName + ' ' + e.LastName AS [Employee], a.AddressText AS [Address] 
	FROM Employees e, Addresses a
		WHERE e.AddressID = a.AddressID

-- Task 20
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	   m.FirstName + ' ' + m.LastName AS [Manager],
	   m.ManagerID 
	FROM Employees e
		INNER JOIN Employees m
			ON e.ManagerID = m.EmployeeID
	

-- Task 21
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	 a.AddressText AS [Address],
	 m.FirstName + ' ' + m.LastName AS Manager,
	 m.ManagerID 
	FROM Employees e
		JOIN Employees m
			ON e.ManagerID = m.EmployeeID
		JOIN Addresses a
			ON e.AddressID = a.AddressID

-- Task 22
SELECT Name 
	FROM Departments
	UNION
SELECT Name 
	FROM Towns

-- Task 23.1 Show employees who have managers and managers
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	m.FirstName + ' ' + m.LastName AS [Manager]
	FROM Employees e
	RIGHT OUTER JOIN Employees m
	ON e.EmployeeID = m.ManagerID

-- Task 23.2 Show employees, managers and employees that don't have manager
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	m.FirstName + ' ' + m.LastName AS [Manager]
	FROM Employees e
	LEFT OUTER JOIN Employees m
	ON e.EmployeeID = m.ManagerID

-- Task 24
SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	   d.Name AS [DepartmentName],
	   e.HireDate
	FROM Employees e
		JOIN Departments d
			ON (d.Name IN ('Sales', 'Finance')
			AND (e.HireDate > '1995' AND e.HireDate < '2005'))

		-- It's the same
		--ON d.Name = 'Sales'
		--OR d.Name = 'Finance'
		--WHERE YEAR(e.HireDate) > 1995 AND YEAR(e.HireDate) < 2005
		
