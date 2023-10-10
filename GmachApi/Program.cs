using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbContext, GmachimSaraAndShaniContext>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // הוסף כאן את המקור שאליו תרצה לאפשר גישה
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddDbContext<GmachimSaraAndShaniContext>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(MapperConfig.Instance);
});

builder.Services.AddSingleton(mapperConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin"); // השתמש ב-CORS Policy שיצרנו

app.MapControllers();

app.Run();

