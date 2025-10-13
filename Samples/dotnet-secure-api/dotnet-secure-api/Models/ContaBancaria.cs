namespace dotnet_secure_api.Data;

public class ContaBancaria
{
    public Guid Id { get; set; }
    public string NumeroConta { get; set; }
    public string NomeTitular { get; set; }
    public decimal Saldo { get; set; }
}