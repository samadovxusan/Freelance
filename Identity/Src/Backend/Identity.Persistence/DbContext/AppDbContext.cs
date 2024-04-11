using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.DbContext;

public class AppDbContext:Microsoft.EntityFrameworkCore.DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        
}