# Video Game Character API

A RESTful API built with ASP.NET Core for managing video game characters. This project demonstrates core backend concepts including service architecture, REST endpoints, and API documentation.

---

## 📖 Development Notes

This project was built following the tutorial: **Build a .NET 10 Web API from Scratch (Controllers, EF Core, SQL Server, DTOs)** by Patrick God.

- YouTube Link: https://www.youtube.com/watch?v=RwQVRXEs370&t=2255s

Adapted for development in Visual Studio Code instead of Visual Studio with W3Tutorials.net (Last Updated: Jan 16, 2026)

- link:https://www.w3tutorials.net/blog/how-can-i-install-and-use-entity-framework-core-in-visual-studio-code/ .

---

## 🎮 Features

- ✅ Get all video game characters
- ✅ Get a character by ID
- ✅ Add a new character
- ✅ Update an existing character
- ✅ Delete a character

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** ASP.NET Core (.NET 10)
- **Architecture:** REST API
- **Documentation:** Swagger / OpenAPI
- **Version Control:** Git & GitHub

---

## 📁 Project Structure

```
.
├── Controllers/                      # API endpoint handlers
├── Models/                           # Data models
├── Services/                         # Business logic
├── Properties/
├── Program.cs                        # Application configuration
├── VideoGameCharacterApi.csproj      # Project file
├── VideoGameCharacterApiNet.sln      # Solution file
├── appsettings.json                  # Configuration settings
└── README.md                         # This file
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) or later

Check your installed version:

```bash
dotnet --version
```

### Installation & Running

1. Clone the repository:

```bash
git clone git@github.com:cararcel/VideoGameCharacterApi.git
cd VideoGameCharacterApi
```

2. Run the API:

```bash
dotnet run
```

The API will be available at `https://localhost:5001`

---

## 📡 API Endpoints

| Method | Endpoint                        | Description            |
| ------ | ------------------------------- | ---------------------- |
| GET    | `/api/VideoGameCharacters`      | Get all characters     |
| GET    | `/api/VideoGameCharacters/{id}` | Get character by ID    |
| POST   | `/api/VideoGameCharacters`      | Create a new character |
| PUT    | `/api/VideoGameCharacters/{id}` | Update a character     |
| DELETE | `/api/VideoGameCharacters/{id}` | Delete a character     |

## 📘 API Documentation (Scalar)

This project uses **Scalar** as an API documentation interface.

Scalar provides a clean and interactive UI to explore and test endpoints, similar to Swagger UI but with a more modern developer experience.

Once the API is running, access it at:

http://localhost:5100/scalar/#tag/videogamecharacters

---

## 🐳 Why Docker?

This project includes a Docker setup to ensure a consistent development environment, especially when working on Linux.

Using Docker allows:

- Running the API in an isolated container
- Avoiding local dependency issues
- Ensuring the same setup across different machines
- Preparing for future integration with databases (e.g., SQL Server)

Run the project with:

docker compose up --build

### Example Request

```bash
curl https://localhost:5001/api/VideoGameCharacters
```

---

## 📚 What I Learned

- Building REST APIs with ASP.NET Core
- Structuring backend projects using controllers and services
- Working with C# in a web context
- Using Git and GitHub in a real project workflow

---

## 🔮 Future Improvements

- [ ] Add a database (SQL Server or PostgreSQL)
- [ ] Implement DTOs (Data Transfer Objects)
- [ ] Add validation and error handling
- [ ] Use async/await properly
- [ ] Add unit tests
- [ ] Implement authentication & authorization
