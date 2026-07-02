# CatCareApi

A RESTful API built with ASP.NET Core for managing cats and their care history.
It tracks cats, breeds, owners, vet visits, vaccines, medications, and weight records.

---

## Overview

This project uses a layered ASP.NET Core structure with controllers, services, DTOs,
Entity Framework Core, and a containerized SQL Server database.

### Key decisions

- Layered architecture: Controllers -> Services -> DTOs
- Entity Framework Core Code First migrations
- SQL Server running in Docker
- Cat profiles return related owner, breed, and care history data

---

## Features

- Get, create, update, and delete cats
- Create and list breeds, with breed optional when registering a cat
- Create and list owners
- Add vet visits to a cat
- Add vaccines to a cat
- Add medications to a cat
- Add weight records to a cat

---

## Tech Stack

- Language: C#
- Framework: ASP.NET Core (.NET 10)
- Database: SQL Server (Docker)
- ORM: Entity Framework Core
- API Documentation: OpenAPI / Scalar
- Tools: Docker, Git

---

## Project Structure

```text
.
├── Controllers/          # API endpoints
├── Models/               # Domain models
├── Models/Dtos/          # Data Transfer Objects
├── Services/             # Business logic
├── Migrations/           # EF Core migrations
├── Program.cs            # App configuration
├── appsettings.json      # Configuration
├── docker-compose.yml    # SQL Server container
└── README.md
```

---

## Database Setup

### 1. Start the database

```bash
docker compose up -d
```

### 2. Verify the container is running

```bash
docker compose ps
```

### 3. Apply migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run --project CatCareApi.csproj
```

In Development, the app automatically applies pending migrations and seeds fake data
if the `Cats` table is empty. After startup, check seeded cats at:

```text
GET http://localhost:5100/api/cats
```

---

## API Endpoints

| Method | Endpoint                         | Description             |
| ------ | -------------------------------- | ----------------------- |
| GET    | /api/cats                        | Get all cats            |
| GET    | /api/cats/{id}                   | Get cat by ID           |
| POST   | /api/cats                        | Create a cat            |
| PUT    | /api/cats/{id}                   | Update a cat            |
| DELETE | /api/cats/{id}                   | Delete a cat            |
| GET    | /api/breeds                      | Get all breeds          |
| POST   | /api/breeds                      | Create a breed          |
| GET    | /api/owners                      | Get all owners          |
| POST   | /api/owners                      | Create an owner         |
| POST   | /api/cats/{catId}/vet-visits     | Add a vet visit         |
| POST   | /api/cats/{catId}/vaccines       | Add a vaccine           |
| POST   | /api/cats/{catId}/medications    | Add a medication        |
| POST   | /api/cats/{catId}/weights        | Add a weight record     |

---

## Future Improvements

- Add validation attributes and clearer error responses
- Add authentication for owner-specific records
- Add update and delete endpoints for individual care records
- Add unit and integration tests
