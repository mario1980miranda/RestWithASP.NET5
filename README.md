# RestWithASP.NET5

## Scaffonding command

### Create a solution :
```bash
dotnet new sln -o RestWithASPNET
```
### Go to the directory
```bash
cd .\RestWithASPNET\
```
### Create a WebAPI project
```bash
dotnet new webapi -o RestWithASPNET
```
### Associate Solution to the Project
```bash
dotnet sln add .\RestWithASPNET\RestWithASPNET.csproj
```
### Run app with certificate
```bash
dotnet run
```

## Database dependency
### Nuget : 
- Pomelo.EntityFrameworkCore.MySql
- 3.2.0
### appsettings.json
```json
"MySQLConnection": {
  "MySQLConnectionString": "Server=localhost;DataBase=rest_with_asp_net;Uid=root;Pwd=admin123"
},
```
## Versioning api
### ASP.NET Core
- Link : https://github.com/dotnet/aspnet-api-versioning
### Nuget dependency 
- Microsoft.AspNetCore.Mvc.Versioning
- Version : 4.1.1
## Migrations
### Nuget dependencies
- Evolve (Database migration tool) - Version : 2.4.0
- Serilog (Simple .NET logging) - Version : 2.10.0
- Serilog.AspNetCore - Version : 3.4.0
- Serilog.Sinks.Console Version : 3.1.1
