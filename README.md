# aspnetcore-restapi-fundamentals

Learning and exploring how to build a REST API with ASP.NET Core step-by-step, from a basic local CRUD API to a Docker-hosted database and JWT authentication.

## Roadmap

### Stage 0 — Project setup
- Create the ASP.NET Core Web API project
- Add a small README
- Add a `.gitignore`

### Stage 1 — Local CRUD (Postman)
- Build a REST API that I can test with Postman
- Store data locally (in-memory or simple local storage)
- Implement full CRUD functionality

### Stage 2 — Base CRUD controller
- Create a reusable base CRUD controller
- Inherit it in a `Product` controller (only table in this stage)

### Stage 3 — Real database + Docker
- Add a real database
- Use Docker to run/connect to the database
- Keep the API clean and maintainable

### Stage 4 — Pagination + seeding
- Add pagination to list endpoints
- Seed the database with 1,000+ entries automatically

### Stage 5 — Auth (JWT)
- Add login/authentication
- Protect endpoints with JWT