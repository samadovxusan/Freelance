using Crm.Application.User.Madels;
using Xunarmand.Domain.Common.Queries;

namespace Crm.Application.Users.Queries;

public class UserGetQueries:IQuery<ICollection<UserDto>>
{
    public UserFilter Filter { get; set; }
    
}