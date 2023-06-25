using EnergyCompanyManager.Application.Queries;
using EnergyCompanyManager.Application.Services;
using EnergyCompanyManager.Domain.Validators;
using FluentValidation;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEndpointService, EndpointService>();
builder.Services.AddScoped<IEndpointQuery, EndpointQuery>();
builder.Services.AddScoped<IValidator<Endpoint>, EndpointValidator>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
