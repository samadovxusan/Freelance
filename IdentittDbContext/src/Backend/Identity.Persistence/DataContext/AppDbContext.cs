using Identity.Domain.Common.Entities;
using Identity.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.DataContext;

public class AppDbContext:IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider serviceProvider) : base(options)
    {
        this.Services = serviceProvider;
    }
    
    public DbSet<User> Users { get;set; }
    public IServiceProvider Services { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Services));
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}