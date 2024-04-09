using Identity.Domain.Common.Entities;

namespace Identity.Domain.Entites;

public class User:AuditTableEntity
{
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    
    
}