using KAOW.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com PostgreSQL
builder.Services.AddDbContext<CrisisDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar suporte ao Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adiciona suporte a Controllers

var app = builder.Build();

// Configuração do Swagger para desenvolvimento
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Configurar roteamento

app.Run();