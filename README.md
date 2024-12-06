# Sportify
**Sportify** is a .NET based eCommerce focused on sports products

## Features
- Product management (add, update, delete products)
- RESTful API for managing products
- Swagger API documentation

 ## Technologies used
  - **ASP.NET Core 8.8**: Backend for building the web API
  - **C#**: Primary language for API development
  - **In-memorie Data Store**: for development purpose, the project uses as in-memory data store for managing products, brands and types.
  - **Swagger**: For API documentation and testing
  - **Entity Framework Core(Planned)**: ORM for database management (planned for future commits)

 ## Setup Instructions
1.Clone reposotiry:
```bash
  git clone https://github.com/yllkakamberi/Sportify.git
```
2.Navigate to the project directory:
   ```bash
cd Sportify
```
3.Restore the dependencies:
```bash
dotnet restore
```
4.Run the application
```bash
dotnet run
```
5.Open a web browser and navigate to the Swagger UI for testing the API
```bash
http://localhost:5109
```

