using Microsoft.EntityFrameworkCore;
using Videoteka.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VideotekaDbContext>(options => options.UseInMemoryDatabase("InMem"));
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