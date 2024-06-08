namespace Domain.Entites;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    
    public int Age { get; set; }

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}