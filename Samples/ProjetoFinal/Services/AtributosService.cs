using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services;

public class AtributosService
{
    private readonly AppDbContext _context;

    public AtributosService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Atributos>> ListarTodosAtributosAsync()
    {
        return await _context.AtributosClasse.ToListAsync();
    }

    public async Task<Atributos?> BuscarPorIdAsync(Guid id)
    {
        return await _context.AtributosClasse.FindAsync(id);
    }

    public async Task<Atributos> InserirAtributoAsync(Atributos novoAtributo)
    {
        _context.AtributosClasse.Add(novoAtributo);
        await _context.SaveChangesAsync();
        return novoAtributo;
    }

    public async Task<bool> RemoverAtributoAsync(Guid id)
    {
        var atributo = await _context.AtributosClasse.FindAsync(id);
        if (atributo == null) return false;

        _context.AtributosClasse.Remove(atributo);
        await _context.SaveChangesAsync();
        return true;
    }
}
