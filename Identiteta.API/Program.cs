using Identiteta.API.Data;
using Identiteta.API.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<IdentitetaDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(authenticationOptions =>
//{
//    authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(jwtBearerOptions =>
//{
//    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = configuration["JWT:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
//    };
//});

WebApplication? app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("allowOrigins");

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

PrepareDb.InitializeDataSeed(app);

app.Run();