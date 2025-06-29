
# 📝 Quiz Management System

A web-based application for managing quizzes, users, and results, built with ASP.NET Core MVC and SQL Server. This project provides an intuitive interface for creating, taking, and tracking quizzes efficiently.

## 🌟 Features

- Create and manage quizzes with dynamic question types.
- User management with authentication and authorization.
- Track quiz results and generate performance reports.
- Responsive design powered by Bootstrap 5.

---

## ⚙️ Getting Started

Follow these steps to set up and run the project locally.

### 📋 Prerequisites

- .NET SDK (version 6.0 or later)
- SQL Server (Express or Developer edition)
- Visual Studio or any code editor (e.g., VS Code)
- Git for cloning the repository

### 🔧 Installation Steps

1. Clone the repository and navigate to the project directory:

   ```markdown
   git clone https://github.com/namra-dhol/Quiz-management-
   cd Quiz
   ```

2. Configure the connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=your_server_name;Initial Catalog=QuizDB;Integrated Security=True;TrustServerCertificate=True;"
   }
   ```

   > Note: Replace `your_server_name` with your SQL Server instance (e.g., `DESKTOP-12345\\SQLEXPRESS`).

4. Apply database migrations (if using Entity Framework Core):

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Access the application in your browser:

   ```
   http://localhost:5000
   ```

   or, if HTTPS is enabled:

   ```
   https://localhost:5001
   ```

---

## 🛠️ Technologies Used

* **ASP.NET Core MVC**: For building the web application framework.
* **Entity Framework Core**: For database operations and ORM.
* **SQL Server**: For persistent data storage.
* **Razor Views**: For dynamic and reusable UI components.
* **Bootstrap 5**: For responsive and modern styling.





## 👤 Author

* **Name:** Namra Dhol
* **GitHub:** [namra-dhol](https://github.com/namra-dhol)

---
