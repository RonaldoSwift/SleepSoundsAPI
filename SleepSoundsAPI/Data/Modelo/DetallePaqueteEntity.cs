namespace SleepSoundsAPI.Data.Modelo;

public class DetallePaqueteEntity
{
    public int IdDetalle { get; set; }
    public string? Nombre { get; set; }
    public int CantidadDeMusica { get; set; }
    public int TiempoDeDuracion { get; set; }
    public string? NombreDeCategoria { get; set; }
    public string? Descripcion { get; set; }
}
