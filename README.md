# VCompare

VCompare is a sample application built using ASP.NET Core and Entity Framework Core.

## Getting started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:
* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Launch the application by running:
  ```
  dotnet run --project VCompare.WebAPI
  ```
The API is now up and running. For accessing the Swagger UI, navigate to [https://localhost:5001/swagger](https://localhost:5001/swagger).

### Testing
To run the automated tests:
  1. For the `VCompare.Application` project, run
  ```
  dotnet test VCompare.Application.Tests
  ```
  2. To run the functional tests for the application, run
  ```
  dotnet test VCompare.WebAPI.FunctionalTests
  ```

## Technologies
* .NET Core 2.2
* ASP.NET Core 2.2
* Entity Framework Core 2.2
