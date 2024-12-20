using Microsoft.AspNetCore.Mvc;
using SleepSoundsAPI.Data.UnitOfWork;
using SleepSoundsAPI.Domain.Models;
using SleepSoundsAPI.Domain.Models.Response;
using SleepSoundsAPI.Domain.Services;

namespace SleepSoundsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaqueteController : ControllerBase
{
    private readonly UnitOfWorkDiscover unitOfWorkDiscover;

    public PaqueteController(UnitOfWorkDiscover unitOfWorkDiscover)
    {
        this.unitOfWorkDiscover = unitOfWorkDiscover;
    }

    [HttpGet]
    [Route("obtenerListaDePaquetes")]
    public async Task<ActionResult<IEnumerable<CategoriaComposerEntity>>> ObtenerListaDePquete([FromQuery] bool destacado)
    {
        Thread.Sleep(2000);
        PaqueteResponse paqueteResponse =  await unitOfWorkDiscover.obtenerListaDePaquetes(destacado);
        return Ok(paqueteResponse);
    }

    [HttpGet]
    [Route("obtenerDetalleDePaquetePorID")]
    public async Task<ActionResult<IEnumerable<CategoriaComposerEntity>>> ObtenerDetalleDePaquetePorID([FromQuery] int idDePaquete)
    {
        Thread.Sleep(2000);
        DetallePaqueteResponse detallePaqueteResponse = await unitOfWorkDiscover.obtenerDetalleDePaquetePorID(idDePaquete);
        if (detallePaqueteResponse == null)
    {
        return NotFound("Detalle De Paquete no encontrada.");
    }
        return Ok(detallePaqueteResponse);
    }
}
