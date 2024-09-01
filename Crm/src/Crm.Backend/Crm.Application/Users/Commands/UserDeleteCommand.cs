using Xunarmand.Domain.Common.Commands;

namespace Crm.Application.Users.Commands;

public class UserDeleteCommand:ICommand<bool>
{
    public Guid Id { get; set; }
}