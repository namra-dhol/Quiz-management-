-- MST_QuizWiseQuestions tabel proc 

-- join is pending if needed 
------------------------------------------------------------------------------------------------------------------------------

-- exec PR_MST_QuizWiseQuestions_Insert 1,2,12
-- Stored Procedures for MST_QuizWiseQuestions Table Insert
CREATE OR ALTER PROC PR_MST_QuizWiseQuestions_Insert
@QuizID INT,
@QuestionID INT,
@UserID INT
AS
BEGIN
	INSERT INTO [dbo].[MST_QuizWiseQuestions]( QuizID,QuestionID,UserID)VALUES
	(										   
		@QuizID,							   
		@QuestionID,
		@UserID
	)
END

-- exec PR_MST_QuizWiseQuestions_Update 
-- Stored Procedures for MST_QuizWiseQuestions Table Update

CREATE OR ALTER PROC PR_MST_QuizWiseQuestions_Update
@QuizWiseQuestionsID INT,
@QuizID INT,
@QuestionID INT,
@UserID INT
AS
BEGIN
	UPDATE [dbo].[MST_QuizWiseQuestions]
	SET 
		[dbo].[MST_QuizWiseQuestions].[QuizID] = @QuizID,
		[dbo].[MST_QuizWiseQuestions].[QuestionID] = @QuestionID,
		[dbo].[MST_QuizWiseQuestions].[UserID] = @UserID,
		[dbo].[MST_QuizWiseQuestions].[Modified] = getdate()
	WHERE [dbo].[MST_QuizWiseQuestions].[QuizWiseQuestionsID] = @QuizWiseQuestionsID
END


-- exec PR_MST_QuizWiseQuestions_Delete 
-- Stored Procedures for MST_QuizWiseQuestions Table Delete


CREATE OR ALTER PROC PR_MST_QuizWiseQuestions_Delete
@QuizWiseQuestionsID INT
AS
BEGIN
	DELETE FROM [dbo].[MST_QuizWiseQuestions]
	WHERE [dbo].[MST_QuizWiseQuestions].[QuizWiseQuestionsID] = @QuizWiseQuestionsID
END



-- exec PR_MST_QuizWiseQuestions_SelectAll
-- Stored Procedures for MST_QuizWiseQuestions Table SelectAll
 
CREATE OR ALTER PROC PR_MST_QuizWiseQuestions_SelectAll
AS
BEGIN
	SELECT 
		[dbo].[MST_QuizWiseQuestions].[QuizWiseQuestionsID],
		[dbo].[MST_QuizWiseQuestions].[QuizID],
		[dbo].[MST_QuizWiseQuestions].[QuestionID],
		[dbo].[MST_QuizWiseQuestions].[UserID],
		[dbo].[MST_QuizWiseQuestions].[Created],
		[dbo].[MST_QuizWiseQuestions].[Modified]
	FROM [dbo].[MST_QuizWiseQuestions]
END



-- exec PR_MST_QuizWiseQuestions_SelectByID 1
-- Stored Procedures for MST_QuizWiseQuestions Table SelectByID


CREATE OR ALTER PROC PR_MST_QuizWiseQuestions_SelectByID
@QuizWiseQuestionsID INT
AS
BEGIN
	SELECT 
		[dbo].[MST_QuizWiseQuestions].[QuizWiseQuestionsID],
		[dbo].[MST_QuizWiseQuestions].[QuizID],
		[dbo].[MST_QuizWiseQuestions].[QuestionID],
		[dbo].[MST_QuizWiseQuestions].[UserID],
		[dbo].[MST_QuizWiseQuestions].[Created],
		[dbo].[MST_QuizWiseQuestions].[Modified]
	FROM [dbo].[MST_QuizWiseQuestions]
	WHERE [dbo].[MST_QuizWiseQuestions].[QuizWiseQuestionsID] = @QuizWiseQuestionsID
END