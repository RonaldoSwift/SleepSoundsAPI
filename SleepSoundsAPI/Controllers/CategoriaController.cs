using Microsoft.AspNetCore.Mvc;
using SleepSoundsAPI.Data.UnitOfWork;
using SleepSoundsAPI.Domain.Models;
using SleepSoundsAPI.Domain.Models.Response;
using SleepSoundsAPI.Domain.Services;

namespace SleepSoundsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly SleepService sleepService;
    private readonly UnitOfWorkDiscover unitOfWorkDiscover;

    public CategoriaController(SleepService sleepService, UnitOfWorkDiscover unitOfWorkDiscover)
    {
        this.sleepService = sleepService;
        this.unitOfWorkDiscover = unitOfWorkDiscover;
    }

    [HttpGet]
    [Route("mensaje")]
    public async Task<ActionResult<IEnumerable<CategoriaComposerEntity>>> ObtenerListaDePquete([FromQuery] string categoriaComposer)
    {
        IEnumerable<CategoriaComposerEntity> paquetes;
        paquetes = await sleepService.ObtenerCategoriaComposer(categoriaComposer);
        return Ok(paquetes);
    }

[HttpGet]
    [Route("obtenerListaDeCategoriaComposer")]
    public async Task<ActionResult<IEnumerable<CategoriaComposerEntity>>> ObtenerListaDeCategoriaComposer([FromQuery] string categoria)
    {
        Thread.Sleep(2000);
        CategoriaComposerResponse categoriaComposerResponse = await unitOfWorkDiscover.obtenerListaDeCategoriaComposer(categoria);
        return Ok(categoriaComposerResponse);
    }
}
