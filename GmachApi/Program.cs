using AutoMapper;
using Repositories;
using Repositories.Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbContext, GmachimSaraAndShaniContext>();

//builder.Services.AddSingleton(typeof(Repositories.IDbContext), typeof( GmachimSaraAndShaniContext));

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

app.MapControllers();

app.Run();
