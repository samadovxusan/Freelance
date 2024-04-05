using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Common.Entities;

public class User:IdentityUser,IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; } = default;
    public DateTimeOffset? ModifiedTime { get; set; }= default;
}