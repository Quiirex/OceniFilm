using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

var secret = "Thisismytestprivatekey";
var key = Encoding.UTF8.GetBytes(secret);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false
    };
});
builder.WebHost.ConfigureAppConfiguration(config => config.AddJsonFile("ocelot.json"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseAuthentication();
app.UseOcelot().Wait();
app.Run();