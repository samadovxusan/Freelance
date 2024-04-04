using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);

        builder.HasData(new User
        {
            Id = Guid.Parse("6d3503ab-1a35-47b9-be09-b24ff4fbf6df"),
            RoleId = Guid.Parse("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
            Name = "admin",
            Password = "123456",
        });

    }
        
}