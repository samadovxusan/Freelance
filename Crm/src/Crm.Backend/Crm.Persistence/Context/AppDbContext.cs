using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Persistence.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
    public DbSet<User> Users { get; set; }
}