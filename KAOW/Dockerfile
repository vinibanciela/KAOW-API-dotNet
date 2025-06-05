# Etapa base (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Criar usuário sem privilégios administrativos
RUN useradd -ms /bin/bash kaowuser
USER kaowuser

# Definir variável de ambiente Production
ENV ASPNETCORE_ENVIRONMENT=Production

# Expor porta padrão 8080
EXPOSE 8080

# Etapa build (SDK do .NET)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1) Copiar C# project file e restaurar dependências
COPY ["KAOW.csproj", "./"]
RUN dotnet restore "KAOW.csproj"

# 2) Copiar todo o restante do código-fonte
COPY . .

# 3) Construir (build) o projeto em modo Release
RUN dotnet build "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 4) Publicar (publish) a aplicação em /app/publish
RUN dotnet publish "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final (Runtime puro, sem SDK, apenas para execução da aplicação)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# 5) Copiar somente a saída de publish - aplicação publicada - para o container final
COPY --from=build /app/publish .

# 6) Comando padrão para executar a API: Executar a DLL gerada
ENTRYPOINT ["dotnet", "KAOW.dll"]
