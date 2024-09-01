using Crm.Application.User.Madels;
using Xunarmand.Domain.Common.Commands;

namespace Crm.Application.Users.Commands;

public class UserUpdateCommand:ICommand<UserDto>
{
    public UserDto? UserDto { get; set; }
    
}