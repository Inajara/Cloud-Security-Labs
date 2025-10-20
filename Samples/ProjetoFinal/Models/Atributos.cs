using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models;

public class Atributos
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Range(0, 100)]
    public int Forca { get; set; }

    [Range(0, 100)]
    public int Destreza { get; set; }

    [Range(0, 100)]
    public int Inteligencia { get; set; }

    [Range(0, 100)]
    public int Fe { get; set; }

    [Range(0, 100)]
    public int Velocidade { get; set; }
    
    public Atributos()
    {
        var rdn = new Random();
        Forca = rdn.Next(1, 11);
        Destreza = rdn.Next(1, 11);
        Inteligencia = rdn.Next(1, 11);
        Fe = rdn.Next(1, 11);
        Velocidade = rdn.Next(1, 11);
    }
}