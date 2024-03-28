using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfguration;

public class UserConfiguretion : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Name).IsRequired().HasMaxLength(256);
        builder.Property(user => user.Email).IsRequired().HasMaxLength(256);
        builder.Property(user => user.Password).IsRequired().HasMaxLength(256);
    }
}

