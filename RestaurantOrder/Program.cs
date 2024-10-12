using RestaurantOrderRouting.Api;
using RestaurantOrderRouting.Domain.Interfaces.Services;
using RestaurantOrderRouting.Domain.Services;
using RestaurantOrderRouting.Infrastructure.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<ConsumerBackgroundService>();

// Dependecy Injection - How the project is small, I put the dependency injection directly here
builder.Services.AddScoped<IPublisherOrderService, ProducerOrderQueue>();
builder.Services.AddScoped<IConsumerOrderService, ConsumerOrderQueue>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
