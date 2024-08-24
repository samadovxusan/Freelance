namespace Domain.Common.Entites;

public abstract class AuditTableEntity:Entity, IAudiTableEntity
{
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset ModifiedTime { get; set; }
}