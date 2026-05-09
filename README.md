# Employee Leave Management Portal

A full-stack enterprise-style Employee Leave Management Portal built using ASP.NET Core Web API and Angular.

This project is designed for learning and implementing real-world enterprise concepts including authentication, authorization, exception handling, caching, logging, performance optimization, Docker, CI/CD, and clean architecture.

---

# Tech Stack

## Backend
- ASP.NET Core Web API
- Entity Framework Core
- InMemory Database (initially)
- SQL Server (later)
- JWT Authentication
- Refresh Tokens
- ASP.NET Identity
- Serilog
- FluentValidation
- Swagger/OpenAPI
- xUnit & Moq

## Frontend
- Angular
- Angular Material
- RxJS
- Reactive Forms
- Route Guards
- HTTP Interceptors

## DevOps
- Docker
- Docker Compose
- GitHub Actions CI/CD

---

# Features

## Authentication & Authorization
- JWT Authentication
- Refresh Tokens
- Role-Based Authorization
- Secure Password Hashing
- Claims & Policies

## Employee Management
- Add Employee
- Update Employee
- Delete Employee
- Employee Listing
- Employee Details

## Leave Management
- Apply Leave
- Cancel Leave
- Approve/Reject Leave
- Leave Balance Tracking
- Leave History

## Enterprise Concepts
- Global Exception Handling
- Structured Logging
- Request/Response Logging
- API Validation
- Caching
- Performance Optimization
- Repository Pattern
- Service Layer
- Dependency Injection
- Clean Architecture

## Frontend Features
- Lazy Loading
- Global Error Handling
- Reusable Components
- Responsive UI
- Route Protection
- Token Interceptors

## DevOps & Deployment
- Dockerized Application
- CI/CD Pipeline
- Environment Configuration
- Production Ready Setup

---

# Project Architecture

```text
EmployeeLeaveManagement.sln

src/
│
├── EmployeeLeaveManagement.API
├── EmployeeLeaveManagement.Application
├── EmployeeLeaveManagement.Domain
├── EmployeeLeaveManagement.Infrastructure
│
frontend/
│
└── employee-leave-management-ui