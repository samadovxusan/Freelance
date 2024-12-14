using BookEasy.Domain.Common.Entities;

namespace BookEasy.Domain.Entities;

public class User : AuditableEntity
{
    public string Name { get; set; } = default!;
    
    public string Email { get; set; } = default!;
    
    public string Phone { get; set; } = default!;
    
    public string Password { get; set; } = default!;
    public List<Booking>? Bookings { get; set; }
}