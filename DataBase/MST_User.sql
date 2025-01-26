-- MST_USER table stored proc 


-- exec PR_MST_User_Insert 'namra','namra@123','namradhol@gmail.com','9558794953',1,1
-- Stored Procedures for MST_User Table insert 
CREATE OR ALTER PROC PR_MST_User_Insert
@UserName NVARCHAR(100),
@Password NVARCHAR(100),
@Email NVARCHAR(100),
@Mobile NVARCHAR(100),
@IsActive BIT,
@IsAdmin BIT
AS
BEGIN
	INSERT INTO [dbo].[MST_User](UserName,[Password],Email,Mobile,isActive,IsAdmin)VALUES
	(
		@UserName,
		@Password,
		@Email,
		@Mobile,
		@IsActive,
		@IsAdmin
	)
END

-- exec PR_MST_User_Update 13,'asdf','asdfg@123','asdfghjk@gmail.com','9558794953',0
-- Stored Procedures for MST_User Update
CREATE OR ALTER PROC PR_MST_User_Update
@UserID INT,
@UserName NVARCHAR(100),
@Password NVARCHAR(100),
@Email NVARCHAR(100),
@Mobile NVARCHAR(100),
@IsAdmin BIT
AS
BEGIN
	UPDATE [dbo].[MST_User]
	SET 
		[dbo].[MST_User].[UserName] = @UserName,
		[dbo].[MST_User].[Password] = @Password,
		[dbo].[MST_User].[Email] = @Email,
		[dbo].[MST_User].[Mobile] = @Mobile,
		[dbo].[MST_User].[IsAdmin] = @IsAdmin,
		[dbo].[MST_User].[Modified] = getdate()
	WHERE [dbo].[MST_User].[UserID] = @UserID
END


-- exec PR_MST_User_Delete 13
-- Stored Procedures for MST_User Delete
CREATE OR ALTER PROC PR_MST_User_Delete
@UserID INT
AS
BEGIN
	DELETE FROM [dbo].[MST_User]
	WHERE [dbo].[MST_User].[UserID] = @UserID
END





-- exec PR_MST_User_SelectByID 12
-- Stored Procedures for MST_User SelectByID

CREATE OR ALTER PROC PR_MST_User_SelectByID
@UserID INT
AS
BEGIN
	SELECT 
		[dbo].[MST_User].[UserName],
		[dbo].[MST_User].[Password],
		[dbo].[MST_User].[Email],
		[dbo].[MST_User].[Mobile],
		[dbo].[MST_User].[IsActive],
		[dbo].[MST_User].[IsAdmin],
		[dbo].[MST_User].[Created],
		[dbo].[MST_User].[Modified]
	FROM [dbo].[MST_User]
	WHERE [dbo].[MST_User].[UserID] = @UserID
END


-- exec PR_MST_User_SELECTALL
--Stored Procedures for MST_User SelectAll

create or alter PROC PR_MST_User_SELECTALL
AS 
BEGIN
Select 
	    [dbo].[MST_User].[UserID],
		[dbo].[MST_User].[UserName],
		[dbo].[MST_User].[Password],
		[dbo].[MST_User].[Email],
		[dbo].[MST_User].[Mobile],
		[dbo].[MST_User].[IsActive],
		[dbo].[MST_User].[IsAdmin],
		[dbo].[MST_User].[Created],
		[dbo].[MST_User].[Modified]
from [dbo].[MST_User]
End

