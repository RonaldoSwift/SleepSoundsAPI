using SleepSoundsAPI.Data.Modelo;
using SleepSoundsAPI.Data.UnitOfWork;
using SleepSoundsAPI.DBConnection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<StringConnection>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<UnitOfWorkDiscover>();

string localIP = "192.168.1.58";
builder.WebHost.UseUrls($"http://{localIP}:7023",$"http://{localIP}:5023");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching","HOla","Hola3"
    
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
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
.WithOpenApi();

app.MapGet("/obtenerListaDeMusicaDiscover", async (UnitOfWorkDiscover unitOfWorkDiscover) =>
{
        Thread.Sleep(2000);
    MusicaDiscoverResponse musicaDiscoverResponse  = await unitOfWorkDiscover.obtenerListaDeMusicaDiscover();
    return musicaDiscoverResponse;
})
.WithName("GetObtenerListaDeMusica")
.WithOpenApi();

app.MapGet("/obtenerDetalleDeMusicaPorID", async (UnitOfWorkDiscover unitOfWorkDiscover, int idDeMusica) =>
{
    Thread.Sleep(2000);
    DetalleMusicaDiscoverResponse detalleMusicaDiscoverResponse = await unitOfWorkDiscover.obtenerDetalleDeMusicaPorID(idDeMusica);

    if (detalleMusicaDiscoverResponse == null)
    {
        return Results.NotFound("Detalle De Musica no encontrada.");
    }

    return Results.Ok(detalleMusicaDiscoverResponse);
})
.WithName("GetObtenerDetalleDeMusicaPorID")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
