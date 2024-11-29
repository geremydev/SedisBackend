# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["SedisBackend.Core.Application/SedisBackend.Core.Application.csproj", "SedisBackend.Core.Application/"]
COPY ["SedisBackend.Core.Domain/SedisBackend.Core.Domain.csproj", "SedisBackend.Core.Domain/"]
COPY ["SedisBackend.Infrastructure.Persistence/SedisBackend.Infrastructure.Persistence.csproj", "SedisBackend.Infrastructure.Persistence/"]
COPY ["SedisBackend.Infrastructure.Shared/SedisBackend.Infrastructure.Shared.csproj", "SedisBackend.Infrastructure.Shared/"]
RUN dotnet restore "./WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Instalar dependencias necesarias (OpenSSL y krb5)
RUN apt-get update && apt-get install -y libkrb5-dev openssl ca-certificates && \
    apt-get clean

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll", "ef", "database", "update"]