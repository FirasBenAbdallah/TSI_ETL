# TSI_ERP_ETL Project

## Introduction
This project is a .NET 7.0-based ETL (Extract, Transform, Load) application designed to retrieve data from an Enterprise Resource Planning (ERP) system and insert it into a Microsoft SQL Server database. It utilizes modern .NET features such as the Microsoft.Extensions.Logging for robust logging capabilities, DependencyInjection for managing dependencies, EntityFrameworkCore for ORM support, Configuration for external settings, System.Net.Http.Headers for making HTTP requests, SqlClient for database operations, and LINQ for querying data.

## Features
- Extraction of data from ERP systems
- Data transformation to fit the SQL Server schema
- Efficient loading into Microsoft SQL Server
- Logging of ETL operations
- Configuration through app settings
- Dependency injection for better maintainability
- Entity Framework Core for database interactions

## Prerequisites
- .NET 7.0 SDK
- Microsoft SQL Server
- Access to the target ERP system

## Setup
1. Clone the repository to your local machine.
2. Ensure that .NET 7.0 SDK is installed.
3. Set up a SQL Server instance and ensure it is accessible.
4. Configure the connection strings and other settings in the `appsettings.json` file.

## Usage
To run the ETL process, follow these steps:
1. Navigate to the project directory in your terminal.
2. Build the project using the `dotnet build` command.
3. Run the project using the `dotnet run` command.

## Contributing
Contributions to the TSI_ERP_ETL project are welcome. Please follow these steps to contribute:
1. Fork the repository.
2. Create a new branch for your feature or fix.
3. Commit your changes with clear, descriptive messages.
4. Push the branch to your fork.
5. Open a pull request against the main repository.

Please note that this project adheres to a code of conduct, and all contributions should respect this code.
