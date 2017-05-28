
-- Task 1
CREATE DATABASE TransactSQL
GO

CREATE TABLE Persons
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR (50) NOT NULL,
	SSN VARCHAR(10) NOT NULL
)	
GO

CREATE TABLE Accounts
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	PersonId INT FOREIGN KEY REFERENCES Persons (Id),
	Balance MONEY NOT NULL
)
GO

INSERT INTO Persons (FIrstName, LastName, SSN)
	VALUES
		('Georgi', 'Georgiev', '123456789'),
		('Petko', 'Petkov', '987654321'),
		('Vasil', 'Vasilev', '5432109876')
GO

INSERT INTO Accounts (PersonId, Balance)
	VALUES
		(1, 5000),
		(2, 20000),
		(3, 100000),
		(2, 50000)
GO

-- Create stored procedure
CREATE PROC usp_GetFullNames
AS
	BEGIN
		SELECT FirstName + ' ' + LastName AS [FullName] FROM Persons
	END
GO

-- Execute the stored procedure
EXEC usp_GetFullNames


-- Task 2
CREATE PROC usp_GetMoney
	@currentMoney MONEY
AS
	BEGIN
		SELECT p.FirstName + ' ' + p.LastName  AS [FullName],
			a.Balance
			FROM Accounts a 
				JOIN Persons p
				ON p.Id = a.PersonId
					WHERE a.Balance > @currentMoney
				ORDER BY a.Balance
	END
GO

-- Execute the stored procedure
EXEC usp_GetMoney 10000


-- Task 3
CREATE FUNCTION ufn_CalculateInterestRate(
	@sum MONEY,
	@interestRate DECIMAL(5, 2),
	@numberOfMonths INT)
	RETURNS MONEY
AS
	BEGIN
		DECLARE @result MONEY = @sum*(POWER(1 + @interestRate/12,@numberOfMonths))
		RETURN @result
	END
GO

-- Task 4
ALTER TABLE Accounts
	ADD MoneyFromRate MONEY

	UPDATE Accounts
	SET Balance = 5000
	WHERE Id = 1

CREATE PROC usp_PersonalInterestRateForOneMonth
	@accountId INT,
	@intersetRate DECIMAL(5, 2)
AS
	BEGIN
		UPDATE Accounts
		SET MoneyFromRate = dbo.ufn_CalculateInterestRate(Balance, @intersetRate, 1)
			WHERE Id = @accountId
	END
GO

EXEC usp_PersonalInterestRateForOneMonth 1, 8.5 


-- Task 5
 CREATE PROC usp_WithdrawMoney
	@accountId int,
	@amount money = 0
	AS
		BEGIN TRAN
			UPDATE Accounts
			SET Balance = Balance - @amount
			FROM Accounts 
			WHERE Id = @accountId
		COMMIT TRAN
GO

CREATE PROC usp_DepositMoney
	@accountId int,
	@amount money = 0
	AS
		BEGIN TRAN
			UPDATE Accounts
			SET Balance = Balance + @amount
			FROM Accounts
			WHERE Id = @accountId
		COMMIT TRAN
GO

-- Task 6
CREATE TABLE Logs
	(
		LogID INT NOT NULL IDENTITY PRIMARY KEY,
		AccountID INT FOREIGN KEY REFERENCES Accounts(Id),
		OldSum MONEY,
		NewSum MONEY,
	)
GO

-- trigger to the Accounts
CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
	AS
	BEGIN
		INSERT INTO Logs(AccountID, OldSum, NewSum)
			SELECT i.Id, d.Balance, i.Balance
			FROM inserted AS i
				JOIN deleted AS d
					ON i.Id = d.Id
	END
GO

UPDATE Accounts
	SET Balance = Balance + 100
	WHERE Id = 3
GO