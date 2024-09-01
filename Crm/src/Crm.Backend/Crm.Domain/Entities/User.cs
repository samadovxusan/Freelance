namespace Crm.Domain.Entities;

public class User:AudiTable
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? ImagePath { get; set; }
}