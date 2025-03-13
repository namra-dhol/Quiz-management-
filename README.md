# Quiz-management-
A robust and user-friendly Quiz Management System built with ASP.NET Core MVC and SQL Server, designed to manage quizzes, questions, users, and results efficiently.

## Features

* User Management: Role-based access for administrators and quiz participants.

* Quiz Management:Create quizzes with a specific number of questions.View, search, and edit quizzes.Store quiz details like date, total questions, and assigned users.

* Dynamic Dropdowns: Populate dropdown lists from the database dynamically.




## Tech Stack

**Backend:** 
* ASP.NET Core MVC

* SQL Server

**Frontend:**
* Bootstrap NiceAdmin Theme template




## Setup Instructions

1. Clone the Repository

```bash
  git clone https://github.com/namra-dhol/Quiz-management-.git
  cd Quiz-management-
  cd Quiz
```
2. Configure Database
* Open ```appsettings.json.```
* Update the ```ConnectionStrings``` section with your SQL Server connection details.

```bash
"ConnectionStrings": {
  "ConnectionString": "Server=YourServerName;Database=DatabaseName;Trusted_Connection=True;"
}
```

3. Restore Dependencies
```bash
dotnet restore
```
4.   Add a Database to Your SqlServer and ADD StoredProc

5. Run the Application
```bash
dotnet run
```

## Usage

**Features:**

1. Add Quiz: Navigate to the "Add Quiz" page, fill in the form, and save the quiz.

2. Manage Quizzes: View, search, update, or delete quizzes using the Quiz List page.

3. Dropdown Population: Assign users to quizzes using dynamically populated dropdowns.

4. Search Functionality:
Use the search bar on the Quiz List page to dynamically filter quizzes.


