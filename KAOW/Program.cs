using KAOW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using KAOW.Services;
using KAOW.DTOs; // (caso utilizar DTOs diretamente aqui no futuro)


var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o banco PostgreSQL
builder.Services.AddDbContext<CrisisDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona suporte a controllers e API REST
builder.Services.AddControllers();

// Injeção de dependência para os serviços (camada de lógica de negócio)
builder.Services.AddScoped<InstituicaoService>();
builder.Services.AddScoped<EventoExtremoService>();
builder.Services.AddScoped<BaseEmergenciaService>();
builder.Services.AddScoped<EventoInstituicaoService>();

// Adiciona serviços para documentação da API (Swagger/OpenAPI)
builder.Services.AddEndpointsApiExplorer(); // Necessário para habilitar Swagger em APIs
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // ✅ Permite usar [SwaggerOperation], [ProducesResponseType] etc.

    // 📘 Define metadados da documentação Swagger
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "KAOW API",
        Version = "v1",
        Description = "API para gerenciamento de Instituições, Eventos Extremos e Bases de Emergência"
    });
});

var app = builder.Build();

// Middleware do Swagger SEM restrição de ambiente (funciona em Production e Development)
app.UseSwagger(); // Gera o arquivo JSON da documentação OpenAPI
app.UseSwaggerUI(c =>
{
    // Cria a interface interativa do Swagger para testar os endpoints
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "KAOW API v1");

    // Serve o Swagger UI na raiz do app: http://localhost:{porta}/
    c.RoutePrefix = string.Empty;
});

// Redirecionamento HTTPS (opcional, bom para segurança)
app.UseHttpsRedirection();

// Middleware de autorização (caso houvesse autenticação ou políticas de acesso)
app.UseAuthorization();

// Mapeia os controllers e endpoints da API
app.MapControllers();

// Aplicar migrations automaticamente ao iniciar o app
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CrisisDbContext>();
    context.Database.Migrate(); // Aplica todas as migrations pendentes
}

// Inicia a aplicação
app.Run();