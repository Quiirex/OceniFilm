﻿using Komentiranje.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
bool useSQLServ = true;
string? connectionString = "";

if (useSQLServ)
{
    connectionString = configuration.GetConnectionString("KomentiranjeSQLServ");
    Console.WriteLine("CONNECTION STRING: " + connectionString);
    builder.Services.AddDbContext<KomentiranjeDbContext>(options =>
    {
        options.UseSqlServer(connectionString, o =>
        {
            o.EnableRetryOnFailure();
        });
    });
}
else
{
    builder.Services.AddDbContext<KomentiranjeDbContext>(options => options.UseInMemoryDatabase("InMem"));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(authenticationOptions =>
{
    authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.RequireHttpsMetadata = false;
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["JWT:Issuer"],
        ValidAudience = configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
    };
});


WebApplication? app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

PrepareDb.InitializeDataSeed(app, useSQLServ);

app.Run();