using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTO;
using ProjetoFinal.Models;
using ProjetoFinal.Services;

namespace ProjetoFinal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtributosController : ControllerBase
{
    private readonly AtributosService _atributosService;

    public AtributosController(AtributosService atributosService)
    {
        _atributosService = atributosService;
    }

    [HttpGet]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<IEnumerable<AtributosDTO>>> ListarAtributos()
    {
        var atributos = await _atributosService.ListarTodosAtributosAsync();
        var dto = atributos.Select(a => new AtributosDTO
        {
            Id = a.Id,
            Forca = a.Forca,
            Destreza = a.Destreza,
            Inteligencia = a.Inteligencia,
            Fe = a.Fe,
            Velocidade = a.Velocidade,
            Links = new List<LinkDTO>
            {
                new LinkDTO("self", Url.Action(nameof(BuscarPorId), new { id = a.Id }), "GET"),
                new LinkDTO("delete", Url.Action(nameof(RemoverAtributos), new { id = a.Id }), "DELETE")
            }
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<AtributosDTO>> BuscarPorId(Guid id)
    {
        var atributo = await _atributosService.BuscarPorIdAsync(id);
        if (atributo == null) return NotFound();

        var dto = new AtributosDTO
        {
            Id = atributo.Id,
            Forca = atributo.Forca,
            Destreza = atributo.Destreza,
            Inteligencia = atributo.Inteligencia,
            Fe = atributo.Fe,
            Velocidade = atributo.Velocidade
        };
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Roles = "Mestre,Jogador")]
    public async Task<ActionResult<AtributosDTO>> AdicionarAtributos(CriarAtributoDTO dto)
    {
        var entidade = new Atributos
        {
            Forca = dto.Forca,
            Destreza = dto.Destreza,
            Inteligencia = dto.Inteligencia,
            Fe = dto.Fe,
            Velocidade = dto.Velocidade
        };

        var criado = await _atributosService.InserirAtributoAsync(entidade);

        var retorno = new AtributosDTO
        {
            Id = criado.Id,
            Forca = criado.Forca,
            Destreza = criado.Destreza,
            Inteligencia = criado.Inteligencia,
            Fe = criado.Fe,
            Velocidade = criado.Velocidade
        };

        return CreatedAtAction(nameof(BuscarPorId), new { id = retorno.Id }, retorno);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Mestre")]
    public async Task<IActionResult> RemoverAtributos(Guid id)
    {
        var removido = await _atributosService.RemoverAtributoAsync(id);
        if (!removido) return NotFound();
        return NoContent();
    }
}
