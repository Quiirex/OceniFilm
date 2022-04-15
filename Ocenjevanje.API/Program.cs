using Microsoft.EntityFrameworkCore;
using Ocenjevanje.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OcenjevanjeDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepareDb.InitializeDataSeed(app);

app.Run();