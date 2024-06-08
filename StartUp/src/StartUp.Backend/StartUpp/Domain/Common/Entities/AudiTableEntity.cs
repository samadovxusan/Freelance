namespace Domain.Common.Entities;

public abstract class AudiTableEntity: SoftDeleteEntity, IAuditableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
}