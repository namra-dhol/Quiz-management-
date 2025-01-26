--------------------------City--------------------------
--Select All--
CREATE OR ALTER PROCEDURE PR_GetAllCities
AS
BEGIN
    SELECT CityID, StateID, CountryID, CityName, STDCode, PinCode, CreationDate, UserID
    FROM City;
END;

-- exec PR_GetCityByID 1
--Select by Id--
CREATE OR ALTER PROCEDURE PR_GetCityByID
    @CityID INT
AS
BEGIN
    SELECT CityID, StateID, CountryID, CityName, STDCode, PinCode, CreationDate, UserID
    FROM City
    WHERE CityID = @CityID;
END;


--exec PR_InsertCity 1,1,'asdfghj','7410','360311',1
--Insert--
CREATE OR ALTER PROCEDURE PR_InsertCity
    @StateID INT,
    @CountryID INT,
    @CityName VARCHAR(100),
    @STDCode VARCHAR(50),
    @PinCode VARCHAR(6),
    @UserID INT
AS
BEGIN
    INSERT INTO City (StateID, CountryID, CityName, STDCode, PinCode, UserID)
    VALUES (@StateID, @CountryID, @CityName, @STDCode, @PinCode, @UserID);
END;
--Update--
CREATE OR ALTER PROCEDURE PR_UpdateCity
    @CityID INT,
    @StateID INT,
    @CountryID INT,
    @CityName VARCHAR(100),
    @STDCode VARCHAR(50),
    @PinCode VARCHAR(6),
    @UserID INT
AS
BEGIN
    UPDATE City
    SET StateID = @StateID, CountryID = @CountryID, CityName = @CityName, 
        STDCode = @STDCode, PinCode = @PinCode, UserID = @UserID
    WHERE CityID = @CityID;
END;
--Delete--
CREATE OR ALTER PROCEDURE PR_DeleteCity
    @CityID INT
AS
BEGIN
    DELETE FROM City
    WHERE CityID = @CityID;
END;

