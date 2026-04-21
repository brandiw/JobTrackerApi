# JobTracker API

A .NET Web API for tracking companies, job applications, and interview notes.

## Overview

JobTracker API provides endpoints for managing companies, applications, and notes in a job-search tracking workflow. The API is built with ASP.NET Core Web API and follows standard route-based request handling patterns used in .NET APIs.[cite:1164]

## Technology Used

- .NET / ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Npgsql Entity Framework Core provider
- Swagger / OpenAPI
- JSON over HTTP

## Route Summary

> Update any route below if your controller attribute routes differ.

| Resource | Method | Route | Purpose |
|---|---|---|---|
| Companies | GET | `/api/companies` | Get all companies |
| Companies | GET | `/api/companies/{id}` | Get one company by id |
| Companies | POST | `/api/companies` | Create a new company |
| Companies | PUT | `/api/companies/{id}` | Update a company |
| Companies | DELETE | `/api/companies/{id}` | Delete a company |
| Applications | GET | `/api/applications` | Get all applications |
| Applications | GET | `/api/applications/{id}` | Get one application by id |
| Applications | POST | `/api/applications` or `/api/companies/{companyId}/applications` | Create a new application |
| Applications | PUT | `/api/applications/{id}` | Update an application |
| Applications | DELETE | `/api/applications/{id}` | Delete an application |
| Interview Notes | POST | `/api/applications/{applicationId}/notes` | Create a note for an application |
| Interview Notes | DELETE | `/api/applications/{applicationId}/notes/{noteId}` | Delete a note from an application |

## Data Areas

### Companies

Companies store organization-level information such as company name and location fields like city and state.

### Applications

Applications belong to companies and track fields such as title, status, role type, URL, and applied date.

### Interview Notes

Interview notes belong to an application and support note-taking plus next-step tracking for interview follow-up.

## Local Development

Typical local development flow for an ASP.NET Core Web API includes restoring dependencies, applying database migrations, and running the API locally.

```bash
dotnet restore
dotnet-ef database update
dotnet run
```

## API Documentation

Swagger/OpenAPI is commonly used in ASP.NET Core APIs to explore and test endpoints during development.[cite:1166]

Once the API is running, check the Swagger UI endpoint configured by your application, often something like:

```text
https://localhost:7228/swagger
```


