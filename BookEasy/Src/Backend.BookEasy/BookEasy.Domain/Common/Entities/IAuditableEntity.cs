namespace BookEasy.Domain.Common.Entities;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }
}