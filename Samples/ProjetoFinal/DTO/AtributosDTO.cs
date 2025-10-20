namespace ProjetoFinal.DTO;

public class AtributosDTO
{
    public Guid Id { get; set; }
    public int Forca { get; set; }
    public int Destreza { get; set; }
    public int Inteligencia { get; set; }
    public int Fe { get; set; }
    public int Velocidade { get; set; }
    public List<LinkDTO> Links { get; set; } = new();
}