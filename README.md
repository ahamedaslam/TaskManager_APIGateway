# 🌐 Task Manager API Gateway

A centralized API Gateway built using **Ocelot** for the Task Manager Microservices Platform.

The gateway acts as a single entry point for all client requests and is responsible for routing, service abstraction, security enforcement, and future cross-cutting concerns such as authentication, rate limiting, caching, and logging.

---

## 📖 Overview

The API Gateway sits between the frontend application and backend microservices.

Instead of communicating directly with multiple services, clients communicate with a single gateway endpoint.

### Responsibilities

- Request Routing
- Service Communication
- Centralized Entry Point
- Authentication & Authorization (Future)
- Rate Limiting (Future)
- Request Logging (Future)
- Response Caching (Future)
- Swagger Aggregation (Future)

---

## 🏗 Gateway Architecture

_Add Architecture Diagram Here_

```text
                     Angular Frontend
                            │
                            ▼
                   Ocelot API Gateway
                     (localhost:7000)
                            │
           ┌────────────────┴───────────────┐
           │                                │
           ▼                                ▼

 Authentication Service           Task Manager Service
     (localhost:7001)               (localhost:7002)

           │                                │
           └──────────────┬─────────────────┘
                          ▼

                     SQL Server
```

---

## 🔄 Request Flow

### Authentication Request

```text
Angular Frontend
        │
        ▼

/gateway/auth/login

        │
        ▼

Authentication Service

        │
        ▼

JWT Token Response
```

---

### Task Management Request

```text
Angular Frontend
        │
        ▼

/gateway/taskmanager/getTasks

        │
        ▼

Task Manager Service

        │
        ▼

Task Data Response
```

---

## ⚙ Ocelot Route Configuration

The gateway uses Ocelot to route requests to downstream microservices.

### Authentication Service Route

```text
/gateway/auth/{everything}
            │
            ▼
/api/auth/{everything}
```

---

### Task Manager Service Route

```text
/gateway/taskmanager/{everything}
                 │
                 ▼
/api/taskmanager/{everything}
```

---

## 📌 Example Endpoints

### Authentication Service

#### Client Request

```http
POST /gateway/auth/login
```

#### Forwarded To

```http
POST /api/auth/login
```

---

#### Client Request

```http
POST /gateway/auth/register
```

#### Forwarded To

```http
POST /api/auth/register
```

---

### Task Manager Service

#### Client Request

```http
POST /gateway/taskmanager/getTasks
```

#### Forwarded To

```http
POST /api/taskmanager/getTasks
```

---

#### Client Request

```http
POST /gateway/taskmanager/create
```

#### Forwarded To

```http
POST /api/taskmanager/create
```

---

## 🛠 Technology Stack

| Technology | Purpose |
|------------|---------|
| ASP.NET Core 8 | Web Framework |
| Ocelot | API Gateway |
| Swagger | API Documentation |
| JWT Authentication | Security (Future) |
| Serilog | Logging (Future) |
| Redis | Caching (Future) |
| Docker | Containerization (Future) |

---

## 🎯 Benefits of API Gateway

### Single Entry Point

Clients communicate with:

```text
https://localhost:7000
```

instead of:

```text
https://localhost:7001
https://localhost:7002
```

---

### Service Abstraction

The frontend does not need to know:

- Service URLs
- Service Ports
- Internal Routing Logic

The gateway handles all communication.

---

### Improved Security

Future enhancements include:

- JWT Validation
- Role Validation
- Request Filtering
- Security Policies

---

### Scalability

The gateway can be extended to support:

- Load Balancing
- Service Discovery
- Distributed Caching
- Request Aggregation

---

## 📂 Project Structure

```text
TaskManager_APIGateway
│
├── Program.cs
│
├── ocelot.json
│
├── Configuration
│
├── Middleware
│
├── Properties
│
└── README.md
```

---

## 🚀 Running Locally

### Clone Repository

```bash
git clone https://github.com/ahamedaslam/TaskManager_APIGateway.git
```

### Restore Packages

```bash
dotnet restore
```

### Run Gateway

```bash
dotnet run
```

### Gateway URL

```text
https://localhost:7000
```

---

## 🔮 Upcoming Enhancements

- JWT Authentication at Gateway
- Swagger Aggregation
- Request Logging
- Rate Limiting
- Redis Caching
- Docker Containerization
- Load Balancing
- Service Discovery

---

## 👨‍💻 Author

### Ahamed Aslam

Full-Stack Software Engineer

Technologies:

- ASP.NET Core
- Ocelot API Gateway
- Microservices
- JWT Authentication
- Angular
- SQL Server
- Entity Framework Core
