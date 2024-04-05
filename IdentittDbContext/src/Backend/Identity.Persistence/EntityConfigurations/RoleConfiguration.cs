using Identity.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence.EntityConfigurations;

public class RoleConfiguration:IEntityTypeConfiguration<IdentityRole>
{
    public RoleConfiguration(IServiceProvider services) => this.Services = services;
    public IServiceProvider Services { get; set; }
        
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        var rolemanager = Services.GetRequiredService<RoleManager<IdentityRole>>();
        var roles = Enum.GetNames<Role>().Select(x => new IdentityRole(x.ToUpper()) { NormalizedName = rolemanager.NormalizeKey(x.ToUpper()) });
        builder.HasData(roles);

    }
}