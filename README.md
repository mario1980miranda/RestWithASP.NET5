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
### Nuget dependencies : 
- Pomelo.EntityFrameworkCore.MySql
- 3.2.0
### appsettings.json
```json
"MySQLConnection": {
  "MySQLConnectionString": "Server=localhost;DataBase=rest_with_asp_net;Uid=root;Pwd=admin123"
},
```
### StartUp configurations
#### Configure Services
```csharp
var connection = Configuration["MySQLConnection:MySQLConnectionString"];
services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

if (Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}
```
#### New method
```csharp
private void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
        var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
 ```

## Versioning api
### ASP.NET Core documentation
- Link : https://github.com/dotnet/aspnet-api-versioning
### Nuget dependency 
- Microsoft.AspNetCore.Mvc.Versioning
- Version : 4.1.1
### StartUp
#### Configure Service
```csharp
services.AddApiVersioning();
```
#### Configure
```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
});
```

## Migrations
### Nuget dependencies
- Evolve (Database migration tool) - Version : 2.4.0
- Serilog (Simple .NET logging) - Version : 2.10.0
- Serilog.AspNetCore - Version : 3.4.0
- Serilog.Sinks.Console Version : 3.1.1

## Content negociation
### Nuget dependencies
- Microsoft.AspNetCore.Mvc.Formatters.Xml - Version : 2.2.0
### Add config on StartUp
```csharp
  services.AddMvc(options =>
  {
      options.RespectBrowserAcceptHeader = true;

      options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
      options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

  }).AddXmlSerializerFormatters();
```
## Adding support to swagger
### Nuget dependencies
- Swashbuckle.AspNetCore - Version : 5.6.1
### Change class StartUp
#### Configure Services
```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "REST API's from Zero to Azure with ASP.NET Core #5 and Docker",
            Version = "V1",
            Description = "API RESTFull developed in course 'REST API's from Zero to Azure with ASP.NET Core #5 and Docker'",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Mario Luiz Miranda",
                Url = new Uri("https://github.com/mario1980miranda")
            }
        });
});
```
#### Configure
```csharp
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API's from Zero to Azure with ASP.NET Core #5 and Docker");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);
```
#### Remove launchUrl property from launchSettings.json
```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:8120",
      "sslPort": 44300
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      ~~"launchUrl": "api/person/v1",~~
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "RestWithASPNET": {
      "commandName": "Project",
      "dotnetRunMessages": "true",
      "launchBrowser": true,
      ~~"launchUrl": "api/person/v1",~~
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
