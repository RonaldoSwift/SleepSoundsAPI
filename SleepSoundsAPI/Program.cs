using Microsoft.AspNetCore.Mvc;
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

string localIP = "192.168.0.108";
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

app.MapGet("/obtenerListaDePaquetes", async (UnitOfWorkDiscover unitOfWorkDiscover, [FromQuery] bool destacado) =>
{
        Thread.Sleep(2000);
    PaqueteResponse paqueteResponse  = await unitOfWorkDiscover.obtenerListaDePaquetes(destacado);
    return paqueteResponse;
})
.WithName("GetObtenerListaDePaquete")
.WithOpenApi();

app.MapGet("/obtenerDetalleDePaquetePorID", async (UnitOfWorkDiscover unitOfWorkDiscover, int idDePaquete) =>
{
    Thread.Sleep(2000);
    DetallePaqueteResponse detallePaqueteResponse = await unitOfWorkDiscover.obtenerDetalleDePaquetePorID(idDePaquete);

    if (detallePaqueteResponse == null)
    {
        return Results.NotFound("Detalle De Paquete no encontrada.");
    }

    return Results.Ok(detallePaqueteResponse);
})
.WithName("GetObtenerDetalleDePaquetePorID")
.WithOpenApi();

app.MapGet("/obtenerMusicasPorId", async (UnitOfWorkDiscover unitOfWorkDiscover, int idDeMusica) =>
{
    Thread.Sleep(2000);
    MusicaResponse musicaResponse = await unitOfWorkDiscover.obtenerMusicas(idDeMusica);
    if (musicaResponse == null)
    {
        return Results.NotFound("Detalle De Musica no encontrada.");
    }

    return Results.Ok(musicaResponse);
})
.WithName("GetObtenerMusicasPorID")
.WithOpenApi();

app.MapGet("/obtenerListaDeCategoriaComposer", async (UnitOfWorkDiscover unitOfWorkDiscover, string categoria) =>
{
    Thread.Sleep(2000);
    CategoriaComposerResponse categoriaComposerResponse  = await unitOfWorkDiscover.obtenerListaDeCategoriaComposer(categoria);
    return categoriaComposerResponse;
})
.WithName("GetObtenerListaDeCategoriaComposer")
.WithOpenApi();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
