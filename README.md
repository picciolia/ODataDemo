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
- Docker (opzionale, per l'esecuzione in container)

### Running the Application

#### Esecuzione Locale

1. Clone the repository
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run
```

The application will start and be available at `https://localhost:7149` or `http://localhost:5176`.

#### Esecuzione con Docker

Il progetto include un `Dockerfile` per creare e eseguire l'applicazione in un container Docker.

##### Build dell'immagine Docker:

```bash
docker build -t odata-demo .
```

##### Esecuzione del container:

```bash
docker run -p 8080:8080 odata-demo
```

L'applicazione sarà disponibile su `http://localhost:8080`.

##### Utilizzo con Docker Compose (opzionale):

Puoi creare un file `docker-compose.yml` per semplificare la gestione:

```yaml
version: '3.8'
services:
  odata-demo:
    build: .
    ports:
      - "8080:8080"
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
```

Quindi eseguire:

```bash
docker-compose up --build
```

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
- Docker (containerization)

## Docker Configuration

Il progetto è configurato per essere eseguito in container Docker con:

- **Base image**: `mcr.microsoft.com/dotnet/aspnet:9.0` per il runtime
- **Build image**: `mcr.microsoft.com/dotnet/sdk:9.0` per la compilazione
- **Port**: L'applicazione è esposta sulla porta 8080 nel container
- **Environment**: Configurato per l'ambiente Development di default
- **Multi-stage build**: Ottimizzazione delle dimensioni dell'immagine finale

## License

This project is for demonstration purposes.