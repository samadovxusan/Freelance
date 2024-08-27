using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfigurations:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.HasKey(u => u.Id);
        builder.Property(user => user.Name).HasMaxLength(64);
        builder.Property(user => user.Email).HasMaxLength(128).IsRequired();
        builder.Property(user => user.Password).HasMaxLength(128).IsRequired();
    }
}