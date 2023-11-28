using System.Reflection;
using Application.Services;
using Domain;
using Infrastructure.Persistence.DefaultData;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
        
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        UsuariosDataSeeder.Seed(modelBuilder);
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<RegPersonal> Personales => Set<RegPersonal>();
} 