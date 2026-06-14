using MediatR;
using SegurAppSuite.Application.EventHanlders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registrar MediatR buscando handlers en el proyecto Application
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(SiniestroRegistradoHandler).Assembly)
);

// 🔹 Agregar controladores
builder.Services.AddControllers();

// 🔹 Configurar Swagger (opcional, útil para probar API)
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
