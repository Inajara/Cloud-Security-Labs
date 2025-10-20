using dotnet_secure_api.Models;
using dotnet_secure_api.DTO;
using dotnet_secure_api.Services;
using dotnet_secure_api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_secure_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json", "application/xml")]

public class ContaBancariaController : ControllerBase
{
    //Em memoria para testes iniciais
    //private static List<ContaBancaria> contas = new() { /*seus mocks aqui*/ };
    private readonly ContasBancariasFileRepository _repo;

    public ContaBancariaController(ContasBancariasFileRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ContaBancaria>> Get() => Ok(_repo.GetAll());

    [HttpGet("{id}")]
    public ActionResult<ContaBancaria> GetById(Guid id)
    {
        var contaBancaria = _repo.GetBy(id);
        if (contaBancaria == null) return NotFound();
        return Ok(contaBancaria);
    }

    [HttpPost]
    public ActionResult<ContaBancaria> Post([FromBody] ContaBancariaDTO dto)
    {
        var novaContaBancaria = new ContaBancaria()
        {
            NomeTitular = dto.NomeTitular,
            NumeroConta = ContaGenerator.GerarNumeroConta(),
            Saldo = dto.Saldo
        };
        
        var criado= _repo.Add(novaContaBancaria);
        return CreatedAtAction(nameof(GetById), new {id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody]  ContaBancariaDTO dto)
    {
        var contaBancaria = _repo.GetBy(id);
        if (contaBancaria == null) return NotFound();
        
        contaBancaria.NomeTitular = dto.NomeTitular;
        contaBancaria.Saldo = dto.Saldo;
        
        var ok = _repo.Update(contaBancaria);

        return ok ? NoContent() : NotFound();
    }

    [HttpPatch("{id}/saldo")]
    public IActionResult AtualizaSaldo(Guid id, [FromBody] ContaBancariaDTO dto)
    {
        var contaBancaria = _repo.GetBy(id);
        if(contaBancaria == null) return NotFound();
        
        contaBancaria.Saldo = dto.Saldo;
        var ok = _repo.Update(contaBancaria);

        return ok ? Ok(contaBancaria) : StatusCode(500);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var ok = _repo.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}