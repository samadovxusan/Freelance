using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataContext;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // bu narsa hamma entity configurationlarni registration qiladi
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

