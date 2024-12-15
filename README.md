# EmployeeDemoAppMod9-master
# README for Employee Management System

## Project Overview
The Employee Management System is a robust MAUI desktop application designed to efficiently manage employee and customer data. The application leverages a SQLite database for backend data storage and provides a modern and user-friendly interface for managing records.

## Key Features
- **Employee Management**:
  - Add, view, edit, and delete employee records.
  - Track employee activity status.
- **Customer Management**:
  - Add, view, and manage customer records.
  - Associate customers with specific services.
- **Database Integration**:
  - SQLite database for reliable and efficient data storage.
  - Handles CRUD operations with error management.
- **Exception Handling**:
  - Custom exception handling for database connectivity issues.
  - Ensures application stability during unexpected scenarios.

## Technologies Used
- **Framework**: .NET MAUI
- **Database**: SQLite
- **Languages**: C#
- **Tools**: Visual Studio, SQLite libraries

## Installation
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the solution file `EmployeeDemoApp.sln` in Visual Studio.
3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
4. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

## Usage
1. Launch the application.
2. Navigate using the sidebar:
   - **Dashboard**: View system statistics.
   - **Employees**: Manage employee records.
   - **Customers**: Manage customer records.
3. Use the top menu bar for searching and filtering records.
4. Perform CRUD operations:
   - Add new employees or customers.
   - Edit or delete existing records.

## Application Structure
- **UI Components**:
  - Built with MAUI for cross-platform compatibility.
  - User-friendly layouts with navigation menus and tables.
- **Backend**:
  - Database operations handled through `SqlDatabase.cs`.
- **Core Classes**:
  - `Employee.cs` and `Customer.cs` for managing entities.
- **Exception Handling**:
  - `NoDatabaseConnectionException.cs` for custom error management.

## Testing
- Extensive testing conducted for all CRUD operations.
- Exception handling scenarios verified.

## Contributing
1. Fork the repository.
2. Create a new branch for your feature:
   ```bash
   git checkout -b feature-name
   ```
3. Commit and push changes:
   ```bash
   git commit -m "Add feature"
   git push origin feature-name
   ```
4. Submit a pull request.

## License
This project is licensed under the MIT License.

