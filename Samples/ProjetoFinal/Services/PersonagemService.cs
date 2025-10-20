using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services;

public class PersonagemService
{
    private readonly AppDbContext _context;

    public PersonagemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Personagem>> ListarTodosPersonagensAsync()
    {
        return await _context.Personagens
            .Include(p => p.Classe)
            .ThenInclude(c => c.Atributo)
            .ToListAsync();
    }

    public async Task<Personagem?> BuscarPorIdAsync(Guid id)
    {
        return await _context.Personagens
            .Include(p => p.Classe)
            .ThenInclude(c => c.Atributo)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Personagem> InserirPersonagemAsync(Personagem novoPersonagem)
    {
        _context.Personagens.Add(novoPersonagem);
        await _context.SaveChangesAsync();
        return novoPersonagem;
    }

    public async Task<bool> RemoverPersonagemAsync(Guid id)
    {
        var personagem = await _context.Personagens.FindAsync(id);
        if (personagem == null) return false;

        _context.Personagens.Remove(personagem);
        await _context.SaveChangesAsync();
        return true;
    }
}