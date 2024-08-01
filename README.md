# Product Management System

This project is a simple Product Management System developed using ASP.NET Core and Dapper. The application provides functionality for adding, updating, deleting, and listing products.

## Features

- Add, update, and delete products
- List products
- User-friendly interface
- Fast database interaction using Dapper

## Technologies

- **ASP.NET Core 8**: A modern and powerful framework for web application development.
- **Dapper**: A fast and lightweight micro ORM for .NET.
- **MS SQL Server**: Used for database management.

## Setup

To set up the project on your local machine, follow these steps:

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/harxite/ProductManagementSystem.git
    cd productManagementSystem_MVC
    ```

2. **Restore NuGet Packages**:
    After opening the project, run the following command to restore the required NuGet packages:
    ```bash
    dotnet restore
    ```

3. **Database Configuration**:
    Add your database connection string to the `appsettings.json` file. Update the following example connection string with your own database settings:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
    }
    ```

4. **Database Migrations (Optional)**:
    If there are any database migrations, apply them by running the following command:
    ```bash
    dotnet ef database update
    ```

5. **Run the Project**:
    Start the project using the following command:
    ```bash
    dotnet run
    ```
    The application will be running at [http://localhost:5000](http://localhost:5000).

## Usage

- **Home Page**: Page where products are listed.
- **Add New Product**: Form used to add a new product.
- **Edit Product**: Form used to update details of existing products.
- **Delete Product**: Form used to delete existing products.


