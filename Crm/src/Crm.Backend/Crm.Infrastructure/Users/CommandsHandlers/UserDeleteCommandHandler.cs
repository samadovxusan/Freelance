using Crm.Application.User.Services;
using Crm.Application.Users.Commands;
using Xunarmand.Domain.Common.Commands;

namespace Crm.Infrastructure.Users.CommandsHandlers;

public class UserDeleteCommandHandler(IUserService service):ICommandHandler<UserDeleteCommand,bool>
{
    public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.Id, cancellationToken: cancellationToken);
        if ( result != null)
        {
            return true;
        }
        return false;
    }
}