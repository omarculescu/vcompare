FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /app

RUN ls

COPY . ./
RUN dotnet publish VCompare.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env ["/app/out", "."]
ENTRYPOINT ["dotnet", "VCompare.WebAPI.dll"]
