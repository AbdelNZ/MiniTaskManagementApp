# Task Management App – Clean Architecture Sample

A small but realistic **.NET 9 + React** application built as part of a technical assessment to manage tasks.  
It demonstrates a practical approach to **Clean Architecture**, **DDD-inspired modeling**, and **CQRS**.

---

## 🚀 Tech Stack

### Backend (API – .NET 9)
- Layered **Clean Architecture**: `Domain`, `Application`, `Infrastructure`, `API`
- **CQRS** with MediatR (commands/queries + handlers)
- **DDD-inspired** entities, value objects & repositories
- **EF Core** with **Migrations** (SQL Server)
- **FluentValidation** for input validation
- Basic **Domain Events**
- **Swagger / OpenAPI** for API documentation

### Frontend
- **React + TypeScript**
- Axios for HTTP
- Simple UI to manage projects & tasks

### Testing
- **xUnit** + **Moq** (domain & application layers)

**Other**
- **Unit Tests** with xUnit + Moq
- **Docker Compose** (API + SQL Server)
- **README with setup steps**

---

## 🗂️ Architecture Overview
```
TaskManagementApp/
├── TaskManagementApp.Domain/ # Core domain models & logic
├── TaskManagementApp.Application/ # CQRS (commands, queries, handlers, validation)
├── TaskManagementApp.Infrastructure/ # EF Core repositories, DbContext
├── TaskManagementApp.API/ # Controllers, DI setup, Swagger
├── frontend/ # React + TypeScript UI
├── TaskManagementApp.Tests/ # Unit tests
└── docker-compose.yml # API + DB containers
```

---

## 🧪 Features

- Create and list **Projects**
- Create, list, and complete **Tasks**
- Validation for required fields
- Unit tests for:
  - **Domain layer** (entity behavior)
  - **Application layer** (CQRS handlers)
  - **Validation** (FluentValidation rules)
- Swagger UI for API testing
- Simple React UI for interaction

---

##  Getting Started

### 1. Backend
```bash
cd TaskManagementApp.API
dotnet run
```
API will be available at: http://localhost:5295/swagger

### 2. Frontend
```bash
cd frontend
npm install
npm run dev
```
Frontend will be available at: http://localhost:5173

3. Tests
```bash
dotnet test
```
🐳 Docker Setup
This project includes a Dockerfile for the API and a docker-compose.yml for API + SQL Server.
-The frontend (React app) is not bundled into the Docker setup by default.
In production, it is generally recommended to deploy the frontend separately (e.g., via Nginx, Netlify, or another static hosting service).

This separation follows the principle of keeping backend and frontend deployments independent, which makes scaling, updates, and CI/CD pipelines easier to manage.

Run with:
```bash

docker compose up --build
```
 Note: Running both SQL Server + .NET SDK containers requires at least 4–6 GB of memory allocated to Docker Desktop.
On lower-memory machines, the containers  fail to start.
In such cases, the backend can be run locally with your own SQL Server, while the Docker setup remains valid for standard environments.

📸 Screenshots
Swagger
<img width="1805" height="932" alt="image" src="https://github.com/user-attachments/assets/0b11175e-08db-4922-a2c3-88263c6a66d1" />

Frontend UI
<img width="1693" height="866" alt="image" src="https://github.com/user-attachments/assets/d4495ac5-385b-4b00-8a4d-43c49b78c6a3" />


