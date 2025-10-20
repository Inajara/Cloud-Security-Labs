using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] Login login)
    {
        // Simulação de autenticação
        if (login.Usuario == "mestre" && login.Senha == "123")
            return Ok(new { token = GerarToken("Mestre") });

        if (login.Usuario == "jogador" && login.Senha == "123")
            return Ok(new { token = GerarToken("Jogador") });

        return Unauthorized(new { mensagem = "Usuário ou senha inválidos" });
    }

    private string GerarToken(string role)
    {
        var key = Encoding.UTF8.GetBytes("chavesupersupersecretacriadapeloSams");

        var claims = new[]
        {
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Name, role.ToLower())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}