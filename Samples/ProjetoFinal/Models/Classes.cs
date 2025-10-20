using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models;

public class Classes
{
    [Key]
    public Guid Id { get; set; }

    public string NomeClasse { get; set; }

    [ForeignKey("Atributo")]
    public Guid AtributoId { get; set; }

    public Atributos Atributo { get; set; }
}