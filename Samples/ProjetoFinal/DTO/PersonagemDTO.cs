namespace ProjetoFinal.DTO;

public class PersonagemDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int Nivel { get; set; }
    public ClasseDTO Classe { get; set; }
    public List<LinkDTO> Links { get; set; } = new();
}