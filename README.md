# ASP.NET Core Web API Payment System
A simple payment system where a user can check balance and view payment history

## Codebase Structure

The solution contains following projects.
| Projects | References    |
| ------ | ------ |
| Pera.UtangApi | Pera.UtangApi.Models, Pera.UtangApi.Services |
| Pera.UtangApi.Formulas |  |
| Pera.UtangApi.Models |  |
| Pera.UtangApi.Repositories | Pera.UtangApi.Formulas, Pera.UtangApi.Models |
| Pera.UtangApi.Services | Pera.UtangApi.Models, Pera.UtangApi.Repositories |
| Pera.UtangApi.Tests | Pera.UtangApi.Formulas, Pera.UtangApi.Services |

### Database
The main project uses an in-memory "database" for testing. It aslo seeds some test data if the environment is development.

## Build and Run
Use VS Code Terminal, Powershell or Command Prompt, navigate to the solution folder then run these commands:

```sh
dotnet build
dotnet run --project UtangApi\Pera.UtangApi.csproj
```

## Authentication
The system uses Basic Authentication when using APIs.

### Using Swagger
Follow the link http://localhost:5000/swagger/index.html.
Click the Unlock :unlock: then enter the following credentials:

| Username: | Password:    |
| ------ | ------ |
| demo | demo |

Then click Authorize.

### Using Postman
Click the Authorization tab then select Basic Auth. Enter the same credentials.

## GET Methods
Both methods have accountNumber parameter.
* http://localhost:5000/api/Balances?accountNumber=000000000001
* http://localhost:5000/api/Payments?accountNumber=000000000001

## DevOps
The repository has branches similar to Git-Flow.
