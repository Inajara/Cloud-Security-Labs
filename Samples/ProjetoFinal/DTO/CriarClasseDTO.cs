using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.DTO;

public class CriarClasseDTO
{
    [Required]
    public string NomeClasse { get; set; }

    [Required]
    public Guid AtributoId { get; set; }
}