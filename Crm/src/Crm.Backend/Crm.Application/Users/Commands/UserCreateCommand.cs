using Crm.Application.User.Madels;
using Xunarmand.Domain.Common.Commands;

namespace Crm.Application.Users.Commands;

public class UserCreateCommand:ICommand<UserDto>
{
    public UserDto? UserDto { get; set; }
}