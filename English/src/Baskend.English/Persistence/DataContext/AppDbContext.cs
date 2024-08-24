using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataContext;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
    {
                
    }

    public DbSet<User> Users => Set<User>(); 
        
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}