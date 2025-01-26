----------------------State------------------------

-- exec PR_GetALLStates
--Select All--
CREATE OR ALTER PROCEDURE PR_GetAllStates
AS
BEGIN
    SELECT StateID, CountryID, StateName, StateCode, CreationDate, UserID
    FROM State;
END;

-- exec  PR_GetStateByID 1
--Select by Id--
CREATE OR ALTER PROCEDURE PR_GetStateByID
    @StateID INT
AS
BEGIN
    SELECT StateID, CountryID, StateName, StateCode, CreationDate, UserID
    FROM State
    WHERE StateID = @StateID;
END;

-- exec PR_InsertState 1,'asdfg','asdfgh',1
--Insert--
CREATE OR ALTER PROCEDURE PR_InsertState
    @CountryID INT,
    @StateName VARCHAR(100),
    @StateCode VARCHAR(50),
    @UserID INT
AS
BEGIN
    INSERT INTO State (CountryID, StateName, StateCode, UserID)
    VALUES (@CountryID, @StateName, @StateCode, @UserID);
END;

--exec PR_UpdateState
--Update--
CREATE OR ALTER PROCEDURE PR_UpdateState
    @StateID INT,
    @CountryID INT,
    @StateName VARCHAR(100),
    @StateCode VARCHAR(50),
    @UserID INT
AS
BEGIN
    UPDATE State
    SET CountryID = @CountryID, StateName = @StateName, StateCode = @StateCode, UserID = @UserID
    WHERE StateID = @StateID;
END;
--Delete--
CREATE OR ALTER PROCEDURE PR_DeleteState
    @StateID INT
AS
BEGIN
    DELETE FROM State
    WHERE StateID = @StateID;
END;