using System.ComponentModel.DataAnnotations;

namespace dotnet_secure_api.DTO;

public class ContaBancariaNovoSaldoDTO
{
    [Required]
    public decimal Saldo { get; set; }
}