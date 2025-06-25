
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app


COPY src/PROJE3/PROJE3.csproj ./PROJE3.csproj
RUN dotnet restore PROJE3.csproj


COPY src/PROJE3/. .
RUN dotnet publish PROJE3.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/out ./


ENV ConnectionStrings__DefaultConnection="Server=db,1433;Database=DiabetesDB;User Id=sa;Password=Your_strong@Passw0rd;"

ENTRYPOINT ["dotnet", "PROJE3.dll"]
