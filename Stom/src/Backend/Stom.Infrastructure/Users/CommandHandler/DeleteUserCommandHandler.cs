using MediatR;
using Stom.Application.Users.Commands;
using Stom.Application.Users.Services;

namespace Stom.Infrastructure.Users.CommandHandler;

public class DeleteUserCommandHandler(IUserService userService):IRequestHandler<DeleteUserCommand,bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await userService.DeleteByIdAsync(request.Id, cancellationToken: cancellationToken);
        return true;
    }
}