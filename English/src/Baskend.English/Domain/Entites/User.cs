using Domain.Common.Entites;

namespace Domain.Entites;

public class User:AuditTableEntity
{
    public string Name { get; set; } = string.Empty;
    
    public int Age { get; set; } 
    
    public string Email { get; set; } = string.Empty;
    
    public string? Password { get; set; }
    
}