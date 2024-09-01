using Crm.Application.User.Madels;
using Xunarmand.Domain.Common.Queries;

namespace Crm.Application.Users.Queries;

public class UserGetByIdQueries:IQuery<UserDto>
{
    public Guid Id { get; set; }
    
}