using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.DTO;

public class CriarPersonagemDTO
{
    [Required]
    public string Nome { get; set; }

    [Range(1, 20)]
    public int Nivel { get; set; }

    [Required]
    public Guid ClasseId { get; set; }
}