using MediatR;

namespace Stom.Application.Users.Commands;

public class DeleteUserCommand:IRequest<Boolean>
{
    public Guid Id { get; set; }

}