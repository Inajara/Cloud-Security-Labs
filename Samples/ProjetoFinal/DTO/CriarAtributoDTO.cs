using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.DTO;

public class CriarAtributoDTO
{
    [Range(1, 10)]
    public int Forca { get; set; }

    [Range(1, 10)]
    public int Destreza { get; set; }

    [Range(1, 10)]
    public int Inteligencia { get; set; }

    [Range(1, 10)]
    public int Fe { get; set; }

    [Range(1, 10)]
    public int Velocidade { get; set; }
}