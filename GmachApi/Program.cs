using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Data;
using Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbContext, GmachimSaraAndShaniContext>();

builder.Services.AddTransient<IEmailService, Services.Implemantation.EmailService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
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
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "docs/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/docs/v1/swagger.json", "My API V1");
    });
}

//app.UseHttpsRedirection();

// Enable JWT authentication
app.UseAuthentication();


app.UseAuthorization();

app.UseRouting();


// global cors policy
app.UseCors();
     

app.UseStaticFiles();

app.MapPost("/login", async (HttpContext context) =>
{
    var username = context.Request.Form["username"];
    var password = context.Request.Form["password"];

 

    // if user exist, create a taoken
    if (IsValidUser(username, password))
    {
        var token = GenerateJwtToken(username, IsAdmin(username, password));

        context.Response.Headers.Add("Content-Type", "application/json");
        await context.Response.WriteAsync("{\"token\": \"" + token + "\"}");
    }
    else
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Invalid username or password");
    }
});



app.MapControllers();

app.Run();

bool IsAdmin(string username, string password)
{
    return username == "adPlusadMinus" && password == "15987532";
}
bool IsValidUser(string username, string password)
{
    Services.IServices.IUser user = new Services.Implemantation.User();
    //in case of not register user
    if (username == password && username == "temp")
    {
        return true;
    }
    try
    {
        return user.Login(new DTO.Models.LoginUser() { UserName = username, Password = password}) != null;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
}

//create the token
string GenerateJwtToken(string username, bool Admin)
{
    IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


    string issuer = configuration["JwtSettings:Issuer"];
    string audience = configuration["JwtSettings:Audience"];
    string symmetricKey = configuration["JwtSettings:SymmetricKey"];

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricKey));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, username),

        Admin ?
        new Claim(ClaimTypes.Role, "Admin"):
        new Claim(ClaimTypes.Role, "User"),

    };

    var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}