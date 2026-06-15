using MediatR;
using SegurAppSuite.Application.EventHanlders;
using SegurAppSuite.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 🔹 Registrar servicios de Infrastructure (DbContext + repositorios)
builder.Services.AddInfrastructureServices(builder.Configuration);

// Registrar MediatR buscando handlers en el proyecto Application
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(SiniestroRegistradoHandler).Assembly)
);

// 🔹 Agregar controladores
builder.Services.AddControllers();

// 🔹 Configurar Swagger (opcional, útil para probar API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Swagger middleware
if (app.Environment.IsDevelopment())
{
    // Swagger JSON
    app.UseSwagger();

    // Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SegurAppSuite API V1");
    });

    // Redoc integrado con Swashbuckle
    app.UseReDoc(c =>
    {
        c.RoutePrefix = "docs"; // URL: /docs
        c.SpecUrl = "/swagger/v1/swagger.json";
        c.DocumentTitle = "SegurAppSuite API Docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
