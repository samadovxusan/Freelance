using Microsoft.EntityFrameworkCore;
using Stom.Domain.Entities;

namespace Stom.Persistence.DbContexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){} 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<User> Users => Set<User>();
}