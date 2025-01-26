--MST_Quiz table proc
------------------------------------------------------------------------------------------------------------------------------

-- Creating MST_Quiz table
CREATE TABLE MST_Quiz(
    QuizID INT PRIMARY KEY IDENTITY(1,1),
    QuizName NVARCHAR(100) NOT NULL,
    TotalQuestions INT NOT NULL,
    QuizDate DATETIME NOT NULL,
    UserID INT NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES MST_User(UserID)
);

-- exec PR_MST_Quiz_Insert 'asp.net',10,'2025-2-15',12
-- Stored Procedures for MST_Quiz Table Insert
CREATE OR ALTER PROC PR_MST_Quiz_Insert
@QuizName NVARCHAR(100),
@TotalQuestions INT,
@QuizDate DATETIME,
@UserID INT
AS
BEGIN
	INSERT INTO [dbo].[MST_Quiz](Quizname,totalQuestions,QuizDate,UserId) VALUES
	(
		@QuizName,
		@TotalQuestions,
		@QuizDate,
		@UserID
	)
END

-- exec PR_MST_Quiz_Update 1,'asp.net',20,'2025-2-15',12
-- Stored Procedures for MST_Quiz Table Update

CREATE OR ALTER PROC PR_MST_Quiz_Update
@QuizID INT,
@QuizName NVARCHAR(100),
@TotalQuestions Nvarchar(100),
@QuizDate DATETIME,
@UserID INT
AS
BEGIN
	UPDATE [dbo].[MST_Quiz]
	SET 
		[dbo].[MST_Quiz].[QuizName] = @QuizName,
		[dbo].[MST_Quiz].[TotalQuestions] = @TotalQuestions,
		[dbo].[MST_Quiz].[QuizDate] = @QuizDate,
		[dbo].[MST_Quiz].[UserID] = @UserID,
		[dbo].[MST_Quiz].[Modified] = getdate()
	WHERE [dbo].[MST_Quiz].[QuizID] = @QuizID
END


-- exec PR_MST_Quiz_Delete 1
-- Stored Procedures for MST_Quiz Table Delete
CREATE OR ALTER PROC PR_MST_Quiz_Delete
@QuizID INT
AS
BEGIN
	DELETE FROM [dbo].[MST_Quiz]
	WHERE [dbo].[MST_Quiz].[QuizID] = @QuizID
END



-- exec PR_MST_Quiz_SelectAll
-- Stored Procedures for MST_Quiz Table Select All
CREATE OR ALTER PROC PR_MST_Quiz_SelectAll
AS
BEGIN
	SELECT 
		[dbo].[MST_Quiz].[QuizID],
		[dbo].[MST_Quiz].[QuizName],
		[dbo].[MST_Quiz].[TotalQuestions],
		[dbo].[MST_Quiz].[QuizDate],
		[dbo].[MST_Quiz].[UserID],
		[dbo].[MST_Quiz].[Created],
		[dbo].[MST_Quiz].[Modified]
	from 
	[dbo].[MST_Quiz] join  [dbo].[MST_User]
	on 
	[dbo].[MST_User].[UserId] = [dbo].[MST_Quiz].[UserId]
	order by [dbo].[MST_Quiz].[Quizname],[dbo].[MST_User].[UserName]
end


-- exec PR_MST_Quiz_SelectByID 1
-- Stored Procedures for MST_Quiz Table SelectByID

CREATE OR ALTER PROC PR_MST_Quiz_SelectByID
@QuizID INT
AS
BEGIN
	SELECT 
		[dbo].[MST_Quiz].[QuizID],
		[dbo].[MST_Quiz].[QuizName],
		[dbo].[MST_Quiz].[TotalQuestions],
		[dbo].[MST_Quiz].[QuizDate],
		[dbo].[MST_Quiz].[UserID],
		[dbo].[MST_Quiz].[Created],
		[dbo].[MST_Quiz].[Modified]
	from 
	[dbo].[MST_Quiz] join [dbo].[MST_User]
	on 
	[dbo].[MST_User].[UserId] = [dbo].[MST_Quiz].[UserId]
	WHERE [dbo].[MST_Quiz].[QuizID] = @QuizID
	order by [dbo].[MST_Quiz].[Quizname],[dbo].[MST_User].[UserName]
end
	

