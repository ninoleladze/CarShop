# CarShop

A console car-shop manager built with **C#, .NET 8 and EF Core (SQL Server)**. It keeps a catalog of cars with create, read, update and delete operations through a service layer.

## Structure

- Models/Car.cs — car entity
- Services/Car/ — ICarService + CarService (CRUD)
- Data/DataContext.cs — EF Core DbContext

## Run

```bash
dotnet ef database update --project CarShop
dotnet run --project CarShop
```
