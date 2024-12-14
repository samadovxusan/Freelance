using BookEasy.Domain.Common.Entities;

namespace BookEasy.Domain.Entities;

public class Staff:AuditableEntity
{
    public string Name { get; set; }  = default!;
    
    public string Specialty { get; set; }  = default!;
    
    public List<Booking> Bookings { get; set; } = default!;  
    
    
}