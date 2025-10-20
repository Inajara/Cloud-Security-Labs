using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTO;
using ProjetoFinal.Models;
using ProjetoFinal.Services;

namespace ProjetoFinal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonagemController : ControllerBase
{
    private readonly PersonagemService _personagemService;

    public PersonagemController(PersonagemService personagemService)
    {
        _personagemService = personagemService;
    }

    [HttpGet]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<IEnumerable<PersonagemDTO>>> ListarPersonagens()
    {
        var personagens = await _personagemService.ListarTodosPersonagensAsync();
        var dto = personagens.Select(p => new PersonagemDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Nivel = p.Nivel,
            Classe = new ClasseDTO
            {
                Id = p.Classe.Id,
                NomeClasse = p.Classe.NomeClasse,
                Atributo = new AtributosDTO
                {
                    Id = p.Classe.Atributo.Id,
                    Forca = p.Classe.Atributo.Forca,
                    Destreza = p.Classe.Atributo.Destreza,
                    Inteligencia = p.Classe.Atributo.Inteligencia,
                    Fe = p.Classe.Atributo.Fe,
                    Velocidade = p.Classe.Atributo.Velocidade
                }
            },
            Links = new List<LinkDTO>
            {
                new LinkDTO("self", Url.Action(nameof(BuscarPorId), new { id = p.Id }), "GET"),
                new LinkDTO("delete", Url.Action(nameof(RemoverPersonagem), new { id = p.Id }), "DELETE")
            }
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<PersonagemDTO>> BuscarPorId(Guid id)
    {
        var personagem = await _personagemService.BuscarPorIdAsync(id);
        if (personagem == null) return NotFound();

        var dto = new PersonagemDTO
        {
            Id = personagem.Id,
            Nome = personagem.Nome,
            Nivel = personagem.Nivel,
            Classe = new ClasseDTO
            {
                Id = personagem.Classe.Id,
                NomeClasse = personagem.Classe.NomeClasse,
                Atributo = new AtributosDTO
                {
                    Id = personagem.Classe.Atributo.Id,
                    Forca = personagem.Classe.Atributo.Forca,
                    Destreza = personagem.Classe.Atributo.Destreza,
                    Inteligencia = personagem.Classe.Atributo.Inteligencia,
                    Fe = personagem.Classe.Atributo.Fe,
                    Velocidade = personagem.Classe.Atributo.Velocidade
                }
            }
        };
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<PersonagemDTO>> AdicionarPersonagem(CriarPersonagemDTO dto)
    {
        var entidade = new Personagem
        {
            Nome = dto.Nome,
            Nivel = dto.Nivel,
            ClasseId = dto.ClasseId
        };

        var criado = await _personagemService.InserirPersonagemAsync(entidade);

        var retorno = new PersonagemDTO
        {
            Id = criado.Id,
            Nome = criado.Nome,
            Nivel = criado.Nivel,
            Classe = new ClasseDTO
            {
                Id = criado.Classe.Id,
                NomeClasse = criado.Classe.NomeClasse,
                Atributo = new AtributosDTO
                {
                    Id = criado.Classe.Atributo.Id,
                    Forca = criado.Classe.Atributo.Forca,
                    Destreza = criado.Classe.Atributo.Destreza,
                    Inteligencia = criado.Classe.Atributo.Inteligencia,
                    Fe = criado.Classe.Atributo.Fe,
                    Velocidade = criado.Classe.Atributo.Velocidade
                }
            }
        };

        return CreatedAtAction(nameof(BuscarPorId), new { id = retorno.Id }, retorno);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Mestre")]
    public async Task<IActionResult> RemoverPersonagem(Guid id)
    {
        var removido = await _personagemService.RemoverPersonagemAsync(id);
        if (!removido) return NotFound();
        return NoContent();
    }
}
