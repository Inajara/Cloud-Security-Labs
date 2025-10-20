using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models;

public class Personagem
{
    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public int Nivel { get; set; }

    [ForeignKey("Classe")]
    public Guid ClasseId { get; set; }

    public Classes Classe { get; set; }
}
