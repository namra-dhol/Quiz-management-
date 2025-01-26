use AddressBook

----------------Country---------------------------
-- exec PR_GetAllCountries
--Select All--
CREATE or ALTER PROCEDURE PR_GetAllCountries
AS
BEGIN
    SELECT
	CountryID, 
	CountryName,
	CountryCode,
	CreationDate, 
	UserID
    FROM Country;
END;

-- exec PR_GetCountryByID 1
--Select by ID--
CREATE OR ALTER PROCEDURE PR_GetCountryByID
    @CountryID INT
AS
BEGIN
    SELECT CountryID, CountryName, CountryCode, CreationDate, UserID
    FROM Country
    WHERE CountryID = @CountryID;
END;

--Insert--
-- exec PR_InsertCountry 'india','91',1
CREATE OR ALTER PROCEDURE PR_InsertCountry
    @CountryName VARCHAR(100),
    @CountryCode VARCHAR(50),
    @UserID INT
AS
BEGIN
    INSERT INTO Country (CountryName, CountryCode, UserID)
    VALUES (@CountryName, @CountryCode, @UserID);
END;
-- exec PR_UpdateCountry 
--Update--
CREATE OR ALTER PROCEDURE PR_UpdateCountry
    @CountryID INT,
    @CountryName VARCHAR(100),
    @CountryCode VARCHAR(50),
    @UserID INT
AS
BEGIN
    UPDATE Country
    SET CountryName = @CountryName, CountryCode = @CountryCode, UserID = @UserID
    WHERE CountryID = @CountryID;
END;

--exec PR_DeleteCountry 
--Delete--
CREATE OR ALTER PROCEDURE PR_DeleteCountry
    @CountryID INT
AS
BEGIN
    DELETE FROM Country
    WHERE CountryID = @CountryID;
END;




