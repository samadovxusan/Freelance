namespace Identity.Domain.Common.Entities;

public interface ISoftDeleteEntity:IEntity
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
    
}