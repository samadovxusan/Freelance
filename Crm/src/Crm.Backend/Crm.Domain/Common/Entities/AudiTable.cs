namespace Crm.Domain.Entities;

public class AudiTable:Entity,IAudiTable
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}