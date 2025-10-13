using System.ComponentModel.DataAnnotations;

namespace dotnet_secure_api.DTO;

public class ContaBancariaCreateDTO
{
    [Required]
    public string NomeTitular { get; set; }
    [Required]
    public decimal Saldo { get; set; }
}