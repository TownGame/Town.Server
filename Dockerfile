# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Town.Server/Town.Server.csproj" --disable-parallel
RUN dotnet publish "./Town.Server/Town.Server.csproj" -c release -o /app --no-restore

# Serve
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Town.Server.dll"]
