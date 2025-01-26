--------------------------------User------------------------------------
--exec PR_GetAllUsers
--Select All--
CREATE OR ALTER PROCEDURE [dbo].[PR_GetAllUsers]
AS
BEGIN
    SELECT UserID, UserName, MobileNo, EmailID, CreationDate
    FROM [dbo].[User];
END;


-- exec PR_GetUserByID 2
--Select by id--

CREATE OR ALTER PROCEDURE PR_GetUserByID
    @UserID INT
AS
BEGIN
    SELECT UserID, UserName, MobileNo, EmailID, CreationDate
    FROM [User]
    WHERE UserID = @UserID;
END;
--Insert--
-- exec PR_InsertUser 'Ddemo','9554193261','Demo@gmail.com'
CREATE OR ALTER PROCEDURE PR_InsertUser
    @UserName VARCHAR(100),
    @MobileNo VARCHAR(50),
    @EmailID VARCHAR(100)
AS
BEGIN
    INSERT INTO [User] (UserName, MobileNo, EmailID)
    VALUES (@UserName, @MobileNo, @EmailID);
END;

-- exec PR_UpdateUser 2,'demo','asdfgh','asdfgh@gmail.com'
--Update--
CREATE OR ALTER PROCEDURE PR_UpdateUser
    @UserID INT,
    @UserName VARCHAR(100),
    @MobileNo VARCHAR(50),
    @EmailID VARCHAR(100)
AS
BEGIN
    UPDATE [User]
    SET UserName = @UserName, MobileNo = @MobileNo, EmailID = @EmailID
    WHERE UserID = @UserID;
END;

--exec PR_DeleteUser 2
--Delete--
CREATE OR ALTER PROCEDURE PR_DeleteUser
    @UserID INT
AS
BEGIN
    DELETE FROM [User]
    WHERE UserID = @UserID;
END;