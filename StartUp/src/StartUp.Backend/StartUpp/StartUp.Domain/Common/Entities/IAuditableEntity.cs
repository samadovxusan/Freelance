namespace StartUp.Domain.Common.Entities;

public interface IAuditableEntity: ISoftDeleteEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
    
}