using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public interface IApplicationDbContext
{
    public DbSet<Siniestro> Siniestros { get; }
    public DbSet<Tercero> Terceros { get; }
    public DbSet<Usuario> Usuarios { get; }
    public DbSet<RegPersonal> Personales { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}