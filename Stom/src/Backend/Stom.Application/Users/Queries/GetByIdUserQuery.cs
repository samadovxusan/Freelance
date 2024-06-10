using MediatR;
using Stom.Application.Users.Models;

namespace Stom.Application.Users.Queries;

public class GetByIdUserQuery:IRequest<UserDto>
{
    public Guid Id { get; set; }
}