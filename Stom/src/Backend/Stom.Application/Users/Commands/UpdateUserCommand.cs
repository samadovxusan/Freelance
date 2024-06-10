using MediatR;
using Stom.Application.Users.Models;

namespace Stom.Application.Users.Commands;

public class UpdateUserCommand:IRequest<UserDto>
{
    public UserDto UserDto { get; set; }
}