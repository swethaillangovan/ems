
# Project Description
The Employee Management System is a web application designed to manage employee data.

# API (Backend)
Technologies Used
Programming Language: C#
Framework: ASP.NET Core Web API
Database: SQL Server
ORM: ADO.NET with Stored Procedures

## Features**
CRUD operations for managing employee data (Create, Read, Update, Delete)
Pagination for listing employees
CORS enabled for cross-origin requests

## Prerequisites
.NET SDK 6.0 or later
SQL Server

## Steps to Build and Run

### 1.Clone the Repository
```
git clone git@github.com:swethaillangovan/ems.git
cd api\EmployeeManagementSystem
```
### 2.Set Up the Database
Create a SQL Server database.
Execute the provided SQL script in **Scripts** folder to create tables and stored procedures.
### 3.Update Configuration
Update the appsettings.json file with your database connection string.
```
{
  "ConnectionStrings": {
    "DBConnection": "YourDatabaseConnectionString"
  }
}
```
### 4.Restore NuGet Packages
```
dotnet restore
```
### 5. Build the Application
```
dotnet build
```
### 6. Run the Application
```
dotnet run
```

## Endpoints
* GET /api/Employee?page={page}&pageSize={pageSize}
* GET /api/Employee/{id}
* POST /api/Employee
* PUT /api/Employee/{id}
* DELETE /api/Employee/{id}

________________________________________________________

# UI (Frontend)

## Technologies Used
* Programming Language: TypeScript
* Framework: Angular 18.1.1
* UI Library: Angular Material
* Package Manager: npm

## Features
* List employees with pagination
* Add new employee
* Edit existing employee
* Delete employee
* Responsive design with Angular Material

## Prerequisites
* Node.js (v18.17.1)
* npm (v9.9.3 or compatible)
* Angular CLI (compatible with Angular 18.1.1)

## Steps to Build and Run
### 1. Install Angular CLI
```
npm install -g @angular/cli@16.0.0
```
### 2. Clone the Repository
```
git clone git@github.com:swethaillangovan/ems.git
cd \ems-ui\ems-ui
```
### 3. Install Dependencies
```
npm install -g npm@9
```
### 4. Update Environment Configuration
```
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7139/api'
};
```
### 5. Build the Application
```
ng build
```
### 6. Run the Application
```
ng serve
```
* The application will be available at http://localhost:4200.

## Pages
* **Employee List:*** Displays list of employees with options to add, edit, or delete employees.
* **Employee Form:** Form to create or edit employee details.

___________________________________

# Notes
* Ensure that both the API and UI applications are running concurrently.
* Adjust the CORS settings in the API if running on different domains or ports.
* Make sure to configure the correct database connection strings and environment settings for both development and production environments.
