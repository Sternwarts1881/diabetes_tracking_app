FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY src/DiabetesTrackerApp/*.csproj ./DiabetesTrackerApp/
RUN dotnet restore DiabetesTrackerApp/DiabetesTrackerApp.csproj

COPY src/DiabetesTrackerApp/. ./DiabetesTrackerApp/
WORKDIR /app/DiabetesTrackerApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/DiabetesTrackerApp/out ./

ENTRYPOINT ["dotnet", "DiabetesTrackerApp.dll"]
