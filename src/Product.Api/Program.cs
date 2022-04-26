using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure;
using ProductApi.Integrations;
using ProductApi.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(Assembly.GetExecutingAssembly());
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddSingleton<IHostedService, MassTransitConsoleHostedService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(cfg => cfg.PostProcess = d => d.Info.Title = "Product Api");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
