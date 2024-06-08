namespace Domain.Common.Entities;

public abstract class SoftDeleteEntity: Entity, ISoftDeleteEntity
{
    public bool IsDelete { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
}