using Domain.Enum;

namespace Domain.Common.Entities;

public class Role
{
    
    public Guid Id { get; set; }

    public RoleType Type { get; set; }
    
    public bool IsDisabled { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime ModifiedTime { get; set; }
}