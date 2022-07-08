using Identiteta.API.Data;
using Identiteta.API.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
bool useSQLServ = true;
string? connectionString = "";

if (useSQLServ)
{
    connectionString = configuration.GetConnectionString("IdentitetaSQLServ");
    Console.WriteLine("CONNECTION STRING: " + connectionString);
    builder.Services.AddDbContext<IdentitetaDbContext>(options =>
    {
        options.UseSqlServer(connectionString, o =>
        {
            o.EnableRetryOnFailure();
        });
    });
}
else
{
    builder.Services.AddDbContext<IdentitetaDbContext>(options => options.UseInMemoryDatabase("InMem"));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<AuthService>();

WebApplication? app = builder.Build();

app.MapControllers();

PrepareDb.InitializeDataSeed(app, useSQLServ);

app.Run();