# Etapa base (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Criar usuário sem privilégios administrativos
RUN useradd -ms /bin/bash kaowuser
USER kaowuser

# Definir variável de ambiente obrigatória
ENV ASPNETCORE_ENVIRONMENT=Production

# Expor porta 8080
EXPOSE 8080

# Etapa build (SDK do .NET)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar arquivos do projeto para o container e restaurar dependências
COPY ["KAOW.csproj", "./"]
RUN dotnet restore "KAOW.csproj"

# Copiar todos os arquivos do projeto
COPY . .

# Build do projeto
RUN dotnet build "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final com SDK (para permitir EF migrations e comandos)
FROM build AS final
WORKDIR /app

# Copiar toda a pasta do projeto para garantir que o dotnet ef funcione (inclui código-fonte e ferramentas locais)
COPY . .

# Restaurar ferramentas locais, incluindo dotnet-ef
RUN dotnet tool restore

# Comando de entrada padrão
ENTRYPOINT ["dotnet", "KAOW.dll"]
