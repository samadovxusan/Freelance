namespace Domain.Common.Entites;

public abstract class Entity:IEntity
{
    public Guid Id { get; set; }
}