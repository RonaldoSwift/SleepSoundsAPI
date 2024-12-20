namespace SleepSoundsAPI.Domain.Models;

public class MusicaEntity
{
    public int Id { get; set; }
    public string? Artista { get; set; }
    public string? Titulo { get; set; }
    public string? Album { get; set; }
    public int IdDePaquete { get; set; }
    public string? UrlDeMusica { get; set; }
}
