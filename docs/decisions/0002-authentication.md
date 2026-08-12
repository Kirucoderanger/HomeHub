# ADR-0002: ASP.NET Core Identity

## Decision

HomeHub will use ASP.NET Core Identity for user authentication
and authorization.

## Reason

ASP.NET Core Identity provides secure, established authentication
functionality for the .NET ecosystem and integrates directly with
Entity Framework Core and Azure SQL.

Using Identity avoids implementing password storage and authentication
mechanisms manually.

## Database

Identity data will be stored in the HomeHub Azure SQL database.

## Planned Roles

- User
- Property Owner
- Administrator

## Status

Accepted
