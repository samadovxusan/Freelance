namespace Domain.Common.Entities;

public interface ISoftDeleteEntity:IEntity
{
    public bool IsDelete { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
}