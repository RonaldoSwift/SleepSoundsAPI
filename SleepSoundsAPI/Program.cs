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

app.MapGet("/obtenerListaDePaquetes", async (UnitOfWorkDiscover unitOfWorkDiscover) =>
{
        Thread.Sleep(2000);
    PaqueteResponse paqueteResponse  = await unitOfWorkDiscover.obtenerListaDePaquetes();
    return paqueteResponse;
})
.WithName("GetObtenerListaDePaquete")
.WithOpenApi();

app.MapGet("/obtenerDetalleDePaquetePorID", async (UnitOfWorkDiscover unitOfWorkDiscover, int idDeMusica) =>
{
    Thread.Sleep(2000);
    DetallePaqueteResponse detallePaqueteResponse = await unitOfWorkDiscover.obtenerDetalleDePaquetePorID(idDeMusica);

    if (detallePaqueteResponse == null)
    {
        return Results.NotFound("Detalle De Paquete no encontrada.");
    }

    return Results.Ok(detallePaqueteResponse);
})
.WithName("GetObtenerDetalleDePaquetePorID")
.WithOpenApi();

app.MapGet("/obtenerMusica", async (UnitOfWorkDiscover unitOfWorkDiscover) =>
{
    Thread.Sleep(2000);
    MusicaResponse musicaResponse = await unitOfWorkDiscover.obtenerMusica();
    if (musicaResponse == null)
    {
        return Results.NotFound("Detalle De Musica no encontrada.");
    }

    return Results.Ok(musicaResponse);
})
.WithName("GetObtenerMusica")
.WithOpenApi();

app.MapGet("/obtenerListaDeDestacado", async (UnitOfWorkDiscover unitOfWorkDiscover) =>
{
    Thread.Sleep(2000);
    DestacadoResponse destacadoResponse  = await unitOfWorkDiscover.obtenerDestacado();
    return destacadoResponse;
})
.WithName("GetObtenerListaDeDestacado")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
