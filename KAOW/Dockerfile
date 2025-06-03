# Etapa base (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
RUN useradd -ms /bin/bash kaowuser
USER kaowuser
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

# Etapa build (SDK do .NET)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KAOW.csproj", "./"]
RUN dotnet restore "KAOW.csproj"
COPY . .
RUN dotnet build "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final (SDK + projeto completo para EF)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Copiar a aplicação completa
COPY . .

# Restaurar ferramentas locais, incluindo dotnet-ef
RUN dotnet tool restore

# Comando padrão para executar a API
ENTRYPOINT ["dotnet", "KAOW.dll"]
