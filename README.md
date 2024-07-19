
The Employee Management System is a web application designed to manage employee data efficiently. This system includes two main components: an API backend and a UI frontend. The backend, built with ASP.NET Core Web API, interacts with a SQL Server database to perform CRUD operations on employee data. The frontend, developed using Angular, provides a user-friendly interface to interact with the backend, enabling users to view, add, edit, and delete employee records. The application also incorporates pagination for listing employees, ensuring a smooth and responsive user experience.

API (Backend)
Technologies Used
Programming Language: C#
Framework: ASP.NET Core Web API
Database: SQL Server
ORM: ADO.NET with Stored Procedures
Package Manager: NuGet
Features
CRUD operations for managing employee data (Create, Read, Update, Delete)
Pagination for listing employees
CORS enabled for cross-origin requests
Prerequisites
.NET SDK 6.0 or later
SQL Server
Steps to Build and Run
Clone the Repository
```
git clone <repository-url>
cd EmployeeManagementSystem
```
Set Up the Database

Create a SQL Server database.
Execute the provided SQL script to create tables and stored procedures (you'll need to create these based on your needs).
