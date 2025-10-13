using System.Text;

namespace dotnet_secure_api.Utils;

public static class ContaGenerator
{
    private static readonly Random _random = new();

    public static string GerarNumeroConta()
    {
        var sb = new StringBuilder();
        
        //dois primeiros numeros
        sb.Append(_random.Next(00, 99));
        
        //tres letras minúsculas
        for (int i = 0; i < 3; i++) sb.Append((char)_random.Next('a', 'z' + 1));
        
        //quatro numeros
        sb.Append(_random.Next(0000, 9999));
        
        //hifen + dois numeros
        sb.Append('-');
        sb.Append(_random.Next(00, 99));
        
        return sb.ToString();
    }
}