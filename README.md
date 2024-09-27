
# Project Overview

This project follows a clean architecture pattern with the **Repository-Service** layer to ensure separation of concerns and maintainable code. It is built using **ASP.NET Core 7.0** and **Entity Framework Core 7.0** for seamless data access and handling. The application supports responsive and scalable CRUD operations, and role-based authentication is handled via **ASP.NET Core Identity**.

## Features

- Clean architecture using Repository-Service pattern
- Fully responsive CRUD operations
- Secure authentication and authorization using Identity roles
- Modularized structure for better scalability and maintainability

---

## Project Setup

### Prerequisites

- **.NET 7.0 SDK**: [Download here](https://dotnet.microsoft.com/download/dotnet/7.0)
- **SQL Server**: Ensure you have SQL Server or any supported database.

### Authentication

Authentication is handled using **ASP.NET Core Identity** with role-based authorization. This provides secure access control throughout the application.

### Technologies & Packages Used

- **ASP.NET Core 7.0**
- **Entity Framework Core 7.0** for data access and management
- **ASP.NET Core Identity** for authentication and authorization
- **Newtonsoft.Json** for JSON serialization/deserialization
- **Omu.Awem.Trial** for advanced UI components

---

## Project Structure

This project uses the following layered structure:

1. **Model**: Contains entity definitions.
2. **Repository**: Handles database operations, ensuring that the business logic remains separate from the data layer.
3. **Service**: Implements business logic and interacts with repositories.
4. **Component**: UI components and related services.

### `csproj` Configuration

Here's the configuration of the main project file (`.csproj`):

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="7.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.2.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="7.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Abstractions" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Analyzers" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="7.0.0" />
    <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="7.0.12" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="Omu.Awem.Trial" Version="7.0.5" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Model\Model.csproj" />
    <ProjectReference Include="..\Repository\Repository.csproj" />
    <ProjectReference Include="..\Service\Service.csproj" />
    <ProjectReference Include="..\Component\Component.csproj" />
  </ItemGroup>
</Project>
```

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-repo.git
cd your-repo
```

### 2. Build and Run the Project

Ensure you have the **.NET 7.0 SDK** installed.

```bash
dotnet build
dotnet run
```

### 3. Configure Database

Update your **appsettings.json** with the correct connection string for your SQL Server.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 4. Apply Migrations

Apply any pending migrations to create or update the database schema:

```bash
dotnet ef database update
```

---

## Contribution Guidelines

Feel free to contribute by:

- Forking the repository
- Creating a new branch
- Submitting a pull request

---

## License

This project is licensed under the MIT License.
