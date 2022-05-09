using Identiteta.API.Data;
using Identiteta.API.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
bool SQLServ = false;
string? connectionString = "";

if (SQLServ)
{
    connectionString = configuration.GetConnectionString("sqlserver-identiteta");
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
//builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("allowOrigins");

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

PrepareDb.InitializeDataSeed(app, SQLServ);

app.Run();