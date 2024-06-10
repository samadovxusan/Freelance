using MediatR;
using Stom.Application.Users.Models;
using Stom.Domain.Entities;

namespace Stom.Application.Users.Commands;

public class CreateUserCommand:IRequest<UserDto>
{
    public User user { get; set; }
    
}