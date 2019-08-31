FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-env
WORKDIR /app

RUN ls

COPY . ./
RUN dotnet publish VCompare.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env ["/app/VCompare.WebAPI/out", "."]
ENTRYPOINT ["dotnet", "VCompare.WebAPI.dll"]
