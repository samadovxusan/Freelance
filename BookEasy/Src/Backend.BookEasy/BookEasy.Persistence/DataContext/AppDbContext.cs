using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.DataContext;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
}