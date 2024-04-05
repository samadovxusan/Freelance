namespace Identity.Domain.Common.Entities;

public abstract class AuditTable: Entity,IAuditTable
{
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
}