using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Common.Entities;

public class User:IdentityUser,IEntity
{
    public DateTimeOffset CreatedTime { get; set; } = default;
    public Guid Id { get; set; } = new Guid();
    public DateTimeOffset? ModifiedTime { get; set; }= default;
}