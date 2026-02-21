using OnionApp.Application.Contracts.CarInterfaces;
using OnionApp.Application.Contracts.CategoryInterfaces;
using OnionApp.Application.Extensions;
using OnionApp.Persistence.Concrete.CarRepositories;
using OnionApp.Persistence.Concrete.CategoryRepositories;
using OnionApp.Persistence.Extensions;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddPersistenceServices(builder.Configuration)
    .AddApplicationServices();

builder.Services.AddControllers().AddJsonOptions(config =>
{
    config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
