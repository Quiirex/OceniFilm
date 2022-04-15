using System.Text;
using Identiteta.API.Data;
using Identiteta.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("allowOrigins",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:4200/")
//                .AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});
builder.Services.AddDbContext<IdentitetaDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<FormOptions>(o => {
//    o.ValueLengthLimit = int.MaxValue;
//    o.MultipartBodyLengthLimit = int.MaxValue;
//    o.MemoryBufferThreshold = int.MaxValue;
//});

builder.Services.Configure<IServiceCollection>(serviceCollection =>
{
    serviceCollection.AddAuthentication(authenticationOptions =>
        {
            authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "https://localhost:7165",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("issuerSigningKey123!"))
            };
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("allowOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

PrepareDb.InitializeDataSeed(app);

app.Run();