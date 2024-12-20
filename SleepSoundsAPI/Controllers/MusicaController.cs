using Microsoft.AspNetCore.Mvc;
using SleepSoundsAPI.Data.UnitOfWork;
using SleepSoundsAPI.Domain.Models;
using SleepSoundsAPI.Domain.Models.Response;
using SleepSoundsAPI.Domain.Services;

namespace SleepSoundsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicaController : ControllerBase
{
    private readonly UnitOfWorkDiscover unitOfWorkDiscover;

    public MusicaController(UnitOfWorkDiscover unitOfWorkDiscover)
    {
        this.unitOfWorkDiscover = unitOfWorkDiscover;
    }

    [HttpGet]
    [Route("obtenerMusicasPorIdDePaquete")]
    public async Task<ActionResult<IEnumerable<CategoriaComposerEntity>>> ObtenerMusicasPorIdDePaquete([FromQuery] int idDePaquete )
    {
        Thread.Sleep(2000);
        MusicaResponse musicaResponse = await unitOfWorkDiscover.obtenerMusicas(idDePaquete);
        if (musicaResponse == null)
    {
        return NotFound("Detalle De Musica no encontrada.");
    }
        return Ok(musicaResponse);
    }
}
