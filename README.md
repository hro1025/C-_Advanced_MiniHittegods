# MiniHittegods API

MiniHittegods er et REST API for registrering og håndtering av hittegods.

Prosjektet er laget i **ASP.NET Core** og bruker **PostgreSQL** som database.
Systemet kan startes med **Docker Compose** og inneholder automatiske tester.

---

# Starte prosjektet

Start hele systemet med Docker:

```
docker compose up --build
```

Dette vil:

* starte PostgreSQL databasen
* starte Adminer (database GUI)
* bygge og starte APIet

Når systemet kjører vil følgende tjenester være tilgjengelige:

| Tjeneste | URL                           |
| -------- | ----------------------------- |
| API      | http://localhost:5000         |
| Swagger  | http://localhost:5000/swagger |
| Adminer  | http://localhost:8080         |

---

# Database (Adminer)

Adminer kan brukes til å se databasen i nettleseren.

Åpne:

```
http://localhost:8080
```

Login:

```
System: PostgreSQL
Server: db
Username: admin
Password: admin
Database: minihittegods
```

---

# Swagger

Swagger brukes til å teste APIet.

Åpne:

```
http://localhost:5000/swagger
```

Her kan du:

* se alle API endpoints
* sende requests direkte fra nettleseren
* teste API funksjonalitet

---

# Kjøre tester

Testene kjøres med:

```
dotnet test
```

Alle tester må være grønne for at prosjektet skal være godkjent.

---

# Eksempler på API bruk

## Hent alle items

```
curl http://localhost:5000/api/items
```

## Hent ett item

```
curl http://localhost:5000/api/items/1/getitem
```

## Legg til item

```
curl -X POST http://localhost:5000/api/items \
-H "Content-Type: application/json" \
-d '{"name":"Wallet","description":"Black wallet"}'
```

---

# Teknologi

Prosjektet bruker:

* ASP.NET Core Web API
* PostgreSQL
* Docker Compose
* Swagger
* xUnit tester
