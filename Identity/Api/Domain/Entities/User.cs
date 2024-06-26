﻿namespace Domain.Common.Entities;

public class User:IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
    
}