USE NORTHWND

-- Task 1
CREATE TABLE Cities
(
	[CityId] INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
)

-- Task 2
INSERT INTO Cities
	SELECT DISTINCT e.City FROM
	(
		SELECT DISTINCT City FROM Employees
		UNION
		SELECT DISTINCT City FROM Suppliers
		UNION
		SELECT DISTINCT City FROM Customers
	) e

-- Task 3
	-- Stored procedure
CREATE PROC usp_InsertForeignKeyToCity
	@table NVARCHAR(15)
AS
	BEGIN
		ALTER TABLE [@table]
		ADD CityId INT FOREIGN KEY REFERENCES Cities (CityId)

	END

GO

--EXEC usp_InsertForeignKeyToCity ('Employees')
--EXEC usp_InsertForeignKeyToCity 'Suppliers'
--EXEC usp_InsertForeignKeyToCity 'Customers'

ALTER TABLE Employees
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Suppliers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Customers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

-- Task 4
 -- Stored procedure
UPDATE Employees
CREATE PROC usp_UpdateCityId
	@table NVARCHAR(15)
AS
	BEGIN
		SET CityId =
	(
		SELECT CityId
		FROM Cities
		WHERE Cities.Name = @table.City
	)
	END


UPDATE Employees
	SET CityId =
	(
		SELECT CityId
		FROM Cities
		WHERE Cities.Name = Employees.City
	)

UPDATE Suppliers
	SET CityId =
	(
		SELECT CityId
		FROM Cities
		WHERE Cities.Name = Suppliers.City
	)

UPDATE Customers
	SET CityId =
	(
		SELECT CityId
		FROM Cities
		WHERE Cities.Name = Customers.City
	)

-- Task 5
ALTER TABLE Cities
ADD  UNIQUE (Name)

-- Task 6
INSERT INTO Cities
	SELECT DISTINCT ShipCity FROM Orders
		WHERE ShipCity NOT IN (SELECT Name FROM Cities)
	 
-- Task 7
ALTER TABLE Orders
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

-- Task 8
EXEC sys.sp_rename 'Orders.CityId', 'ShipCityId'
	
-- Task 9
UPDATE Orders
	SET ShipCityId =
	(
		SELECT CityId
		FROM Cities
		WHERE Cities.CityId = Orders.ShipCityId
	)

-- Task 10
ALTER TABLE Orders
	DROP COLUMN ShipCity

-- Task 11
CREATE TABLE Countries
(
	[CountryId]  INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(15) UNIQUE,
)

-- Òàñê 12
ALTER TABLE Cities
ADD CountryId INT FOREIGN KEY REFERENCES Countries(CountryId)

-- Task 13
INSERT INTO Countries
	SELECT Country FROM Employees
		WHERE Country IS NOT NULL
	UNION
	SELECT Country FROM Suppliers
		WHERE Country IS NOT NULL
	UNION
	SELECT Country FROM Customers
		WHERE Country IS NOT NULL
	UNION
	SELECT ShipCountry FROM Orders
		WHERE ShipCountry IS NOT NULL	

-- Task 14
UPDATE Cities
SET Cities.CountryId = CitiesInCountries.CountryId
FROM (
		(SELECT DISTINCT UnionCountries.CityId,
						 UnionCountries.Country,
						 Countries.CountryId 
		FROM 
			(SELECT Country, CityId 
				FROM Employees 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT Country, CityId 
				FROM Suppliers 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT Country, CityId 
				FROM Customers 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT ShipCountry, ShipCityId 
				FROM Orders 
				WHERE ShipCityId IS NOT NULL) UnionCountries 
		JOIN Countries 
			ON Countries.Name = UnionCountries.Country)
	) CitiesInCountries
WHERE 
    Cities.CityId = CitiesInCountries.CityId

-- Task 16
ALTER TABLE Orders
DROP COLUMN ShipCountry

ALTER TABLE Customers
DROP COLUMN Country

ALTER TABLE Employees
DROP COLUMN Country

ALTER TABLE Suppliers
DROP COLUMN Country
