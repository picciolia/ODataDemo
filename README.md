# OData Demo

A demo project showcasing OData implementation in ASP.NET Core.

## Features

- OData endpoints for managing Categories and Products
- Entity Framework Core integration
- RESTful API with OData query capabilities

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run
```

The application will start and be available at `https://localhost:5001` or `http://localhost:5000`.

## API Endpoints

The following OData endpoints are available:

- `/odata/Categories` - Manage categories
- `/odata/Products` - Manage products

## Project Structure

- `Controllers/` - API controllers
- `Data/` - Database context and configuration
- `Models/` - Entity models
- `Program.cs` - Application startup configuration

## Technologies Used

- ASP.NET Core 9.0
- OData
- Entity Framework Core
- Swagger/OpenAPI

## License

This project is for demonstration purposes.