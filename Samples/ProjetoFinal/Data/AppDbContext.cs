using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<Atributos> AtributosClasse { get; set; }
    public DbSet<Classes> ClassesExistentes { get; set; }
    public DbSet<Personagem> Personagens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atributos>().ToTable("Atributos_Gerais");

        modelBuilder.Entity<Classes>()
            .HasOne(c => c.Atributo)
            .WithMany()
            .HasForeignKey(c => c.AtributoId);

        modelBuilder.Entity<Personagem>()
            .HasOne(p => p.Classe)
            .WithMany()
            .HasForeignKey(p => p.ClasseId);
    }
}