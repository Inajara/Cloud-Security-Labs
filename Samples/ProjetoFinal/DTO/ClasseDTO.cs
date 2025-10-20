namespace ProjetoFinal.DTO;

public class ClasseDTO
{
    public Guid Id { get; set; }
    public string NomeClasse { get; set; }
    public AtributosDTO Atributo { get; set; }
    public List<LinkDTO> Links { get; set; } = new();
}