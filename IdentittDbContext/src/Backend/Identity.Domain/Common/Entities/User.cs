using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Common.Entities;

public class User:IdentityUser,IAuditTable
{
    public DateTimeOffset CreatedTime { get; set; } = default;
    public DateTimeOffset? ModifiedTime { get; set; }= default;
}