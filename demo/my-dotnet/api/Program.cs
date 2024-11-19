// demo app
using api.extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerFeature();

var app = builder.Build();
app.Logger.LogInformation("The app api started");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerFeature();
}

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/sensitive", (string? password) =>
{
    return "Access denied!";
});


app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithTags("My-Api")
.WithOpenApi();

var get_version = () => typeof(WeatherForecast).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

app.MapGet("/healthz", () =>
{
    return $"Healthy\n{get_version()}";
});

app.MapGet("/version", get_version);

app.MapFallback(() =>
{
    // show version of app so each deploy is obvious
    return $"Pick a real path!\n\tlike /weatherforecast\n\nVersion: {get_version()}";
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => (int)Math.Round(32.0 + (9.0 / 5.0 * TemperatureC));
}
