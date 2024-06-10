using Stom.Domain.Common.Entities;

namespace Stom.Domain.Entities;

public class User:AuditableEntity
{
  
  public string? Name { get; set; }
  
  public int Age { get; set; }
  
  public string? Email { get; set; }
   
  public string? Password { get; set; }
  
  public string? ImageUrl { get; set; }
}