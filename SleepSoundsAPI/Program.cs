using Microsoft.EntityFrameworkCore;
using SleepSoundsAPI.Data.SleepDbContext;
using SleepSoundsAPI.Data.UnitOfWork;
using SleepSoundsAPI.DBConnection;
using SleepSoundsAPI.Domain.Services;
//Patron de diseño builder (constructor) construlle nuevos objectos 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Comfiguramos para leer de los Json (Development, Staging, produccion)
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// leemos la cadena de coleccion de losarchivos Json
var cadenaDeConneccion = builder.Configuration.GetConnectionString("Cadena") ?? Environment.GetEnvironmentVariable("URL_BASEDEDATOS_PRODUCTION");

builder.Services.AddDbContext<SleepDbContext>(options =>
    options.UseSqlServer(cadenaDeConneccion)
    );
builder.Services.AddScoped<SleepService>();
builder.Services.AddScoped<UnitOfWorkDiscover>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<StringConnection>(builder.Configuration.GetSection("ConnectionStrings"));

//string localIP = "192.168.1.58";
//builder.WebHost.UseUrls($"http://{localIP}:7023", $"http://{localIP}:5023");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapControllers();
app.Run();