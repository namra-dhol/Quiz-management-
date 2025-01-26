-- MST_Question table proc 
------------------------------------------------------------------------------------------------------------------------------

-- exec PR_MST_Question_Insert 'asdf',1,'sdfghj','sdfgh','dfghj','asfghj','asfghj',3,1,12
-- Stored Procedures for MST_Question Table
CREATE OR ALTER PROC PR_MST_Question_Insert
@QuestionText NVARCHAR(MAX),
@QuestionLevelID INT,
@OptionA NVARCHAR(100),
@OptionB NVARCHAR(100),
@OptionC NVARCHAR(100),
@OptionD NVARCHAR(100),
@CorrectOption NVARCHAR(100),
@QuestionMarks INT,
@IsActive BIT,
@UserID INT
AS
BEGIN
	INSERT INTO [dbo].[MST_Question] (QuestionText,QuestionLevelID,OptionA,OptionB,OptionC,OptionD,CorrectOption,QuestionMarks,IsActive,UserID)VALUES
	(
		@QuestionText,
		@QuestionLevelID,
		@OptionA,
		@OptionB,
		@OptionC,
		@OptionD,
		@CorrectOption,
		@QuestionMarks,
		@IsActive,
		@UserID
	)
END

-- exec PR_MST_Question_Update 
-- Stored Procedures for MST_Question Table Update
CREATE OR ALTER PROC PR_MST_Question_Update
@QuestionID INT,
@QuestionText NVARCHAR(MAX),
@QuestionLevelID INT,
@OptionA NVARCHAR(100),
@OptionB NVARCHAR(100),
@OptionC NVARCHAR(100),
@OptionD NVARCHAR(100),
@CorrectOption NVARCHAR(100),
@QuestionMarks INT,
@IsActive BIT,
@UserID INT
AS
BEGIN
	UPDATE [dbo].[MST_Question]
	SET 
		[dbo].[MST_Question].[QuestionText] = @QuestionText,
		[dbo].[MST_Question].[QuestionLevelID] = @QuestionLevelID,
		[dbo].[MST_Question].[OptionA] = @OptionA,
		[dbo].[MST_Question].[OptionB] = @OptionB,
		[dbo].[MST_Question].[OptionC] = @OptionC,
		[dbo].[MST_Question].[OptionD] = @OptionD,
		[dbo].[MST_Question].[CorrectOption] = @CorrectOption,
		[dbo].[MST_Question].[QuestionMarks] = @QuestionMarks,
		[dbo].[MST_Question].[IsActive] = @IsActive,
		[dbo].[MST_Question].[UserID] = @UserID,
		[dbo].[MST_Question].[Modified] = getdate()
	WHERE [dbo].[MST_Question].[QuestionID] = @QuestionID
END

-- exec PR_MST_Question_Delete 
-- Stored Procedures for MST_Question Table Delete
CREATE OR ALTER PROC PR_MST_Question_Delete
@QuestionID INT
AS
BEGIN
	DELETE FROM [dbo].[MST_Question]
	WHERE [dbo].[MST_Question].[QuestionID] = @QuestionID
END

-- exec PR_MST_Question_SelectAll
-- Stored Procedures for MST_Question Table SelectAll
CREATE OR ALTER PROC PR_MST_Question_SelectAll
AS
BEGIN
	SELECT 
		[dbo].[MST_Question].[QuestionID],
		[dbo].[MST_Question].[QuestionText],
		[dbo].[MST_Question].[QuestionLevelID],
		[dbo].[MST_Question].[OptionA],
		[dbo].[MST_Question].[OptionB],
		[dbo].[MST_Question].[OptionC],
		[dbo].[MST_Question].[OptionD],
		[dbo].[MST_Question].[CorrectOption],
		[dbo].[MST_Question].[QuestionMarks],
		[dbo].[MST_Question].[IsActive],
		[dbo].[MST_Question].[UserID],
		[dbo].[MST_Question].[Created],
		[dbo].[MST_Question].[Modified]
	FROM [dbo].[MST_Question]
END

-- exec PR_MST_Question_SelectByID 2
-- Stored Procedures for MST_Question Table SelectByID

CREATE OR ALTER PROC PR_MST_Question_SelectByID
@QuestionID INT
AS
BEGIN
	SELECT 
		[dbo].[MST_Question].[QuestionID],
		[dbo].[MST_Question].[QuestionText],
		[dbo].[MST_Question].[QuestionLevelID],
		[dbo].[MST_Question].[OptionA],
		[dbo].[MST_Question].[OptionB],
		[dbo].[MST_Question].[OptionC],
		[dbo].[MST_Question].[OptionD],
		[dbo].[MST_Question].[CorrectOption],
		[dbo].[MST_Question].[QuestionMarks],
		[dbo].[MST_Question].[IsActive],
		[dbo].[MST_Question].[UserID],
		[dbo].[MST_Question].[Created],
		[dbo].[MST_Question].[Modified]
	FROM [dbo].[MST_Question]
	WHERE [dbo].[MST_Question].[QuestionID] = @QuestionID
END

