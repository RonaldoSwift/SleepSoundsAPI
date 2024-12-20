namespace SleepSoundsAPI.Domain.Models;

public class PaqueteEntity
{
    public int Id { get; set; }
    public string? Imagen { get; set; }
    public string? Nombre { get; set; }
    public int CantidadDeMusica { get; set; }
    public int TiempoDeDuracion { get; set; }
    public string? NombreCategoria { get; set; }
}
