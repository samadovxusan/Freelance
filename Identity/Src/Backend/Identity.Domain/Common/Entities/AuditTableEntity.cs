namespace Identity.Domain.Common.Entities;

public abstract class AuditTableEntity:SoftDeleteEntity,IAuditTableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }
}