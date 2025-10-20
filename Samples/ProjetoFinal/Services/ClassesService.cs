using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services;

public class ClassesService
{
    private readonly AppDbContext _context;

    public ClassesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Classes>> ListarTodasClassesAsync()
    {
        return await _context.ClassesExistentes
            .Include(c => c.Atributo)
            .ToListAsync();
    }

    public async Task<Classes?> BuscarPorIdAsync(Guid id)
    {
        return await _context.ClassesExistentes
            .Include(c => c.Atributo)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Classes> InserirClasseAsync(Classes novaClasse)
    {
        _context.ClassesExistentes.Add(novaClasse);
        await _context.SaveChangesAsync();
        return novaClasse;
    }

    public async Task<bool> RemoverClasseAsync(Guid id)
    {
        var classe = await _context.ClassesExistentes.FindAsync(id);
        if (classe == null) return false;

        _context.ClassesExistentes.Remove(classe);
        await _context.SaveChangesAsync();
        return true;
    }
}