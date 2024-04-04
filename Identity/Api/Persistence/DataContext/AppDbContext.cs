using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataContext;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    
}