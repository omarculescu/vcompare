# VCompare

VCompare is a sample application built using ASP.NET Core and Entity Framework Core.
It comes as an answer for the following requirements:
Develop a model to build up the following two products and to compare these products based on their annual costs. The comparison should accept the following input parameter:
* Consumption (kWh/year)
and create a list of these products with the columns
* Tariff name
* Annual costs (€/year)
The list should be sorted by costs in ascending order.
#### Products
1. Product A
Name: “basic electricity tariff”
Calculation model: base costs per month 5 € + consumption costs 22 cent/kWh Examples:
* Consumption = 3500 kWh/year => Annual costs = 830 €/year (5€ * 12 months = 60 € base costs + 3500 kWh/year * 22 cent/kWh = 770 € consumption costs)
* Consumption = 4500 kWh/year => Annual costs = 1050 €/year (5€ * 12 months = 60 € base costs + 4500 kWh/year * 22 cent/kWh = 990 € consumption costs)
* Consumption = 6000 kWh/year => Annual costs = 1380 €/year (5€ * 12 months = 60 € base costs + 6000 kWh/year * 22 cent/kWh = 1320 € consumption costs)
2. Product B
Name: “Packaged tariff”
Calculation model: 800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30 cent/kWh.
Examples:
* Consumption = 3500 kWh/year => Annual costs = 800 €/year
* Consumption = 4500 kWh/year => Annual costs = 950 €/year (800€ + 500 kWh * 30 cent/kWh = 150 € additional consumption costs)
* Consumption = 6000 kWh/year => Annual costs = 1400 €/year (800€ + 2000 kWh * 30 cent/kWh = 600 € additional consumption costs)
#### RESTful service
Create a RESTful service to retrieve the products via GET
If you write tests for your implementation please provide them with your implementation. Notes: Please implement this task in C#, PHP or JavaScript

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

## Building with Docker
To build an image for this application, run the `docker build` command and tag the image appropriately. For example:
```
docker build -t vcompare.webapi:1.0.0 .
```
To create and run a container with the built image, run
```
docker run -d -p 8080:80 --name VCompare vcompare.webapi:1.0.0
```
The application should now be available at `localhost:8080`. To access the swagger UI, navigate to [http://localhost:8080/swagger](http://localhost:8080/swagger).
