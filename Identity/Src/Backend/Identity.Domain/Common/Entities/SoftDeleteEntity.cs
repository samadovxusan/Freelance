namespace Identity.Domain.Common.Entities;

public abstract class SoftDeleteEntity:Entity ,ISoftDeleteEntity
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
}