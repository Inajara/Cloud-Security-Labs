using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTO;
using ProjetoFinal.Models;
using ProjetoFinal.Services;

namespace ProjetoFinal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
    private readonly ClassesService _classesService;

    public ClassesController(ClassesService classesService)
    {
        _classesService = classesService;
    }

    [HttpGet]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<IEnumerable<ClasseDTO>>> ListarClasses()
    {
        var classes = await _classesService.ListarTodasClassesAsync();
        var dto = classes.Select(c => new ClasseDTO
        {
            Id = c.Id,
            NomeClasse = c.NomeClasse,
            Atributo = new AtributosDTO
            {
                Id = c.Atributo.Id,
                Forca = c.Atributo.Forca,
                Destreza = c.Atributo.Destreza,
                Inteligencia = c.Atributo.Inteligencia,
                Fe = c.Atributo.Fe,
                Velocidade = c.Atributo.Velocidade,
                Links = new List<LinkDTO>
                {
                    new LinkDTO("self", Url.Action(nameof(BuscarPorId), new { id = c.Id }), "GET"),
                    new LinkDTO("delete", Url.Action(nameof(RemoverClasse), new { id = c.Id }), "DELETE")
                }
            }
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<ClasseDTO>> BuscarPorId(Guid id)
    {
        var classe = await _classesService.BuscarPorIdAsync(id);
        if (classe == null) return NotFound();

        var dto = new ClasseDTO
        {
            Id = classe.Id,
            NomeClasse = classe.NomeClasse,
            Atributo = new AtributosDTO
            {
                Id = classe.Atributo.Id,
                Forca = classe.Atributo.Forca,
                Destreza = classe.Atributo.Destreza,
                Inteligencia = classe.Atributo.Inteligencia,
                Fe = classe.Atributo.Fe,
                Velocidade = classe.Atributo.Velocidade
            }
        };
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<ClasseDTO>> AdicionarClasse(CriarClasseDTO dto)
    {
        var entidade = new Classes
        {
            NomeClasse = dto.NomeClasse,
            AtributoId = dto.AtributoId
        };

        var criado = await _classesService.InserirClasseAsync(entidade);

        var retorno = new ClasseDTO
        {
            Id = criado.Id,
            NomeClasse = criado.NomeClasse,
            Atributo = new AtributosDTO
            {
                Id = criado.Atributo.Id,
                Forca = criado.Atributo.Forca,
                Destreza = criado.Atributo.Destreza,
                Inteligencia = criado.Atributo.Inteligencia,
                Fe = criado.Atributo.Fe,
                Velocidade = criado.Atributo.Velocidade
            }
        };

        return CreatedAtAction(nameof(BuscarPorId), new { id = retorno.Id }, retorno);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Mestre")]
    public async Task<IActionResult> RemoverClasse(Guid id)
    {
        var removido = await _classesService.RemoverClasseAsync(id);
        if (!removido) return NotFound();
        return NoContent();
    }
}
