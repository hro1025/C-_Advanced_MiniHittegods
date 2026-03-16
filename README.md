# Starte prosjektet

Docker-konfigurasjonen ligger i mappen **MiniHittegods.Docker**.

Gå først inn i denne mappen:

```
cd MiniHittegods.Docker
```

Start deretter systemet med Docker Compose:

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

Testene ligger i prosjektet **MiniHittegods.Tests**.

Gå først inn i test-mappen:

```
cd MiniHittegods.Tests
```

Kjør deretter testene:

```
dotnet test -V n
```
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
