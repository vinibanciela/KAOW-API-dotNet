# Etapa base (ASP.NET Core Runtime)
# Esta etapa é usada para definir o ambiente de execução padrão
# que inclui o usuário não-root, variáveis de ambiente, e a porta exposta.
# Estas instruções são herdadas pela etapa 'final'
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
# Esta etapa é responsável por compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1) Copiar C# project file e restaurar dependências
# Copia apenas o arquivo .csproj para otimizar o cache da camada do Docker
COPY ["KAOW.csproj", "./"]
RUN dotnet restore "KAOW.csproj"

# 2) Copiar todo o restante do código-fonte
COPY . .

# 3) Construir (build) o projeto em modo Release
RUN dotnet build "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 4) Publicar (publish) a aplicação em /app/publish
RUN dotnet publish "KAOW.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final (Runtime puro, sem SDK, apenas para execução da aplicação)
# Esta etapa é a imagem final e leve que será executada em produção.
# Ela herda o WORKDIR, USER, ENV e EXPOSE definidos na 'base'.
FROM base AS final

# 5) Copiar somente a saída de publish - aplicação publicada - para o contêiner final
# ATENÇÃO: Usamos '--chown=kaowuser:kaowuser' para garantir que os arquivos copiados
# já tenham o 'kaowuser' como proprietário, seguindo o princípio do menor privilégio.
COPY --chown=kaowuser:kaowuser --from=build /app/publish .

# 6) Comando padrão para executar a API: Executar a DLL gerada
ENTRYPOINT ["dotnet", "KAOW.dll"]