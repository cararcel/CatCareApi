# 🎮 VideoGameCharacterApi

A RESTful API built with ASP.NET Core for managing video game characters.
This project demonstrates how to design and structure a backend application using clean architecture principles, Entity Framework Core, and a containerized SQL Server setup.

---

## 🚀 Overview

This project was built as part of my transition into backend development, with a focus on understanding how real-world APIs are structured and configured.

Instead of relying on Visual Studio scaffolding, the application was set up manually in a Linux environment using Visual Studio Code. This approach helped me gain a deeper understanding of backend configuration, database connections, and development workflows.

### Key decisions

- Use of **layered architecture** (Controllers → Services → DTOs)
- Separation of concerns using **DTOs**
- Database managed with **Entity Framework Core (Code First)**
- SQL Server running in a **Docker container** instead of LocalDB

---

## ✨ Features

- Get all video game characters
- Get a character by ID
- Create a new character
- Update an existing character
- Delete a character

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** ASP.NET Core (.NET 10)
- **Database:** SQL Server (Docker)
- **ORM:** Entity Framework Core
- **API Documentation:** Swagger / OpenAPI
- **Tools:** Docker, Git, GitHub

---

## 📁 Project Structure

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

## ⚙️ Database Setup

This project uses **SQL Server in Docker** for a production-like local environment.

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
dotnet run
```

---

## 🔌 API Endpoints

| Method | Endpoint             | Description          |
| ------ | -------------------- | -------------------- |
| GET    | /api/characters      | Get all characters   |
| GET    | /api/characters/{id} | Get character by ID  |
| POST   | /api/characters      | Create new character |
| PUT    | /api/characters/{id} | Update character     |
| DELETE | /api/characters/{id} | Delete character     |

---

## 🧠 What I Learned

- How to structure a backend project using layered architecture
- How to use DTOs to separate API contracts from domain models
- How to configure and connect to a SQL Server database in Docker
- How Entity Framework Core handles migrations and data access
- How to build and test RESTful APIs using Swagger

---

## 📌 Future Improvements

- Add authentication (JWT)
- Add validation and error handling middleware
- Implement repository pattern
- Add unit and integration tests
- Deploy to cloud (Azure or similar)

---

## 📄 License

This project is for learning purposes and part of my developer portfolio.

## 🙏 Acknowledgments

This project was inspired by Patrick God's .NET 10 Web API tutorial.
