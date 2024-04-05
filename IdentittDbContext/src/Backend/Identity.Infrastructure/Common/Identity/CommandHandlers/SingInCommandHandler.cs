using Identity.Application.Common.Identity.Service;
using Identity.Domain.Common.Commands;
using Identity.Domain.Common.Entities;

namespace Identity.Application.Common.Identity.Models;

public class SingInCommandHandler(IAuthService authService):ICommandHandler<SingInDetails, User>
{
    public async Task<User> Handle(SingInDetails request, CancellationToken cancellationToken)
    {
        var user = await authService.SignInAsync(request, cancellationToken);
        return user;
    }
}