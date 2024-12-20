using Microsoft.EntityFrameworkCore;
using SleepSoundsAPI.Data.SleepDbContext;
using SleepSoundsAPI.Domain.Models;

namespace SleepSoundsAPI.Domain.Services;

public class SleepService
{
    private readonly SleepDbContext _sleepDbContext;

    public SleepService(SleepDbContext sleepDbContext)
    {
        _sleepDbContext = sleepDbContext;
    }

    public async Task<List<CategoriaComposerEntity>> ObtenerCategoriaComposer(string categoriaComposer)
    {
        // Esto es un select 
        return await _sleepDbContext.CategoriaComposerEntitys
        .Where(e => e.Categoria == categoriaComposer)
        .ToListAsync();
    }
}
