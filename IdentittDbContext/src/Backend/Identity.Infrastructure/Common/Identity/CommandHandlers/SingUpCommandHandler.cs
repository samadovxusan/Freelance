using Identity.Application.Common.Identity.Commands;
using Identity.Application.Common.Identity.Service;
using Identity.Domain.Common.Commands;

namespace Identity.Application.Common.Identity.Models;

public class SingUpCommandHandler(IAuthService authService):ICommandHandler<SingUpCommand, string>
{
    public async Task<string> Handle(SingUpCommand request, CancellationToken cancellationToken)
    {
        var token = await authService.SignUpAsync(request.SingUpDetails, cancellationToken);
        return token;
    }
}