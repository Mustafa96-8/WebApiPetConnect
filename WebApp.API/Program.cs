using Microsoft.EntityFrameworkCore;
using WebApp.API.Helpers;
using WebApp.Application;
using WebApp.Application.Abstractions;
using WebApp.Application.Services;
using WebApp.Application.Services.IServices;
using WebApp.Infrastracture;
using WebApp.Infrastructure.Reositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PetFamilyDbContext>();
builder.Services.AddScoped<IPetsRepository,PetRepository>();

builder.Services.AddAplication();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();  

app.MapControllers();

app.Run();
