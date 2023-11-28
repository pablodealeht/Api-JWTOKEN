using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public interface IApplicationDbContext
{
    public DbSet<Usuario> Usuarios { get; }
    public DbSet<RegPersonal> Personales { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}