# Video Game Character API

A RESTful API built with ASP.NET Core for managing video game characters. This project demonstrates core backend concepts including service architecture, REST endpoints, and API documentation.

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
