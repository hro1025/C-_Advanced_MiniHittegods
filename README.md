# MiniHittegods API

## Start the project

The Docker configuration is located in the **MiniHittegods.Docker** folder.

First navigate to this folder:

```bash
cd MiniHittegods.Docker
```

Then start the system with Docker Compose:

```bash
docker compose up --build
```

This will:

* start the PostgreSQL database
* start Adminer (database GUI)
* build and start the API

When the system is running the following services will be available:

| Service | URL                           |
| ------- | ----------------------------- |
| API     | http://localhost:5000         |
| Swagger | http://localhost:5000/swagger |
| Adminer | http://localhost:8080         |

---

## Database (Adminer)

Adminer can be used to view the database in a web browser.

Open:

```
http://localhost:8080
```

Login with:

```
System: PostgreSQL
Server: db
Username: admin
Password: admin
Database: minihittegods
```

---

## Swagger

Swagger is used to test the API.

Open:

```
http://localhost:5000/swagger
```

Here you can:

* view all API endpoints
* send requests directly from the browser
* test the API functionality

---

## Run tests

The tests are located in the **MiniHittegods.Tests** project.

First navigate to the test folder:

```bash
cd MiniHittegods.Tests
```

Then run the tests:

```bash
dotnet test -v n
```

---

## Technology

The project uses:

* ASP.NET Core Web API
* PostgreSQL
* Docker Compose
* Swagger
* xUnit tests
