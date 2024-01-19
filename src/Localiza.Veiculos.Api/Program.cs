using Localiza.Veiculos.Api.Middleware;
using Localiza.Veiculos.IoC.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services
    .RegistrarDependencias()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseAuthorization()
    .UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
