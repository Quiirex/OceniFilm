using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
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

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddAuthorization();
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

WebApplication? app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseOcelot().Wait();
app.Run();