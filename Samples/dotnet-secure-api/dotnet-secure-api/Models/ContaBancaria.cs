namespace dotnet_secure_api.Models;

public class ContaBancaria
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NumeroConta { get; set; }
    public string NomeTitular { get; set; }
    public decimal Saldo { get; set; }
}