-- MST_QuestionLevel table proc 

------------------------------------------------------------------------------------------------------------------------------

-- exec PR_MST_QuestionLevel_Insert 'asdfghjk',12
-- Stored Procedures for MST_QuestionLevel Table Insert
CREATE OR ALTER PROC PR_MST_QuestionLevel_Insert
@QuestionLevel NVARCHAR(100),
@UserID INT
AS
BEGIN
	INSERT INTO [dbo].[MST_QuestionLevel](QuestionLevel,UserID) VALUES
	(
		@QuestionLevel,
		@UserID
	)
END


-- exec  PR_MST_QuestionLevel_Update 1,'qwertyuio',12
-- Stored Procedures for MST_QuestionLevel Table Update

CREATE OR ALTER PROC PR_MST_QuestionLevel_Update
@QuestionLevelID INT,
@QuestionLevel NVARCHAR(100),
@UserID INT
AS
BEGIN
	UPDATE [dbo].[MST_QuestionLevel]
	SET 
		[dbo].[MST_QuestionLevel].[QuestionLevel] = @QuestionLevel,
		[dbo].[MST_QuestionLevel].[UserID] = @UserID,
		[dbo].[MST_QuestionLevel].[Modified] = getdate()
	WHERE [dbo].[MST_QuestionLevel].[QuestionLevelID] = @QuestionLevelID
END


-- exec PR_MST_QuestionLevel_Delete 1
-- Stored Procedures for MST_QuestionLevel Table Delete
CREATE OR ALTER PROC PR_MST_QuestionLevel_Delete
@QuestionLevelID INT
AS
BEGIN
	DELETE FROM [dbo].[MST_QuestionLevel]
	WHERE [dbo].[MST_QuestionLevel].[QuestionLevelID] = @QuestionLevelID
END



-- exec PR_MST_QuestionLevel_SelectAll 
-- Stored Procedures for MST_QuestionLevel Table SelectAll
CREATE OR ALTER PROC PR_MST_QuestionLevel_SelectAll
AS
BEGIN
	SELECT 
		[dbo].[MST_QuestionLevel].[QuestionLevelID],
		[dbo].[MST_QuestionLevel].[QuestionLevel],
		[dbo].[MST_QuestionLevel].[UserID],
		[dbo].[MST_QuestionLevel].[Created],
		[dbo].[MST_QuestionLevel].[Modified]
	FROM [dbo].[MST_QuestionLevel]
END


-- exec PR_MST_QuestionLevel_SelectByID 1
-- Stored Procedures for MST_QuestionLevel Table SelectByID


CREATE OR ALTER PROC PR_MST_QuestionLevel_SelectByID
@QuestionLevelID INT
AS
BEGIN
	SELECT 
		[dbo].[MST_QuestionLevel].[QuestionLevelID],
		[dbo].[MST_QuestionLevel].[QuestionLevel],
		[dbo].[MST_QuestionLevel].[UserID],
		[dbo].[MST_QuestionLevel].[Created],
		[dbo].[MST_QuestionLevel].[Modified]
	FROM [dbo].[MST_QuestionLevel]
	WHERE [dbo].[MST_QuestionLevel].[QuestionLevelID] = @QuestionLevelID
END
