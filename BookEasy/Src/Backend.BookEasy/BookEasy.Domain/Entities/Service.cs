using BookEasy.Domain.Common.Entities;

namespace BookEasy.Domain.Entities;

public class Service:AuditableEntity
{
    public string Name { get; set; } = default!;
    
    public decimal Price { get; set; } = default!;
    
    public TimeSpan Duration { get; set; } = default!;
}