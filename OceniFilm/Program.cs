using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using OceniFilm.Data;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


WebApplication? app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();