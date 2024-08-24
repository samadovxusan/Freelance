namespace Domain.Common.Entites;

public interface IAudiTableEntity:IEntity
{
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset ModifiedTime { get; set;}
    
    
}