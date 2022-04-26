using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderApi.Consts;
using OrderApi.Courier.Activities;
using OrderApi.Infrastructure;
using OrderApi.Integrations;
using OrderApi.Saga.SubmitOrderSagas;
using OrderApi.Saga.SubmitOrderTransactionalSaga;
using OrderApi.Services;
using Shared.Contract.Messages.Customer;
using Shared.Contract.Messages.Product;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var massTransitSettingSection = builder.Configuration.GetSection("MassTransitConfig");
var massTransitConfig = massTransitSettingSection.Get<MassTransitConfig>();

builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(Assembly.GetExecutingAssembly());
    x.AddActivities(Assembly.GetExecutingAssembly());
    x.AddRequestClient<TakeProductTransactionMessage>();
    x.AddRequestClient<ChangeCustomerCreditMessage>();
    x.SetKebabCaseEndpointNameFormatter();
    x.AddSagaStateMachine<OrderStateMachine, OrderState>()
    .InMemoryRepository();
    x.AddSagaStateMachine<OrderCourierStateMachine, OrderTransactionState>()
    .InMemoryRepository();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
        //cfg.Host(massTransitConfig.Host, massTransitConfig.VirtualHost,
        //    h =>
        //    {
        //        h.Username(massTransitConfig.Username);
        //        h.Password(massTransitConfig.Password);
        //    }
        //);
        cfg.Host("amqp://guest:guest@localhost:5672");
    });
});

builder.Services.AddSingleton<IHostedService, MassTransitConsoleHostedService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<OrderTransactionSubmittedActivity>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(cfg => cfg.PostProcess = d => d.Info.Title = "Order Api");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
