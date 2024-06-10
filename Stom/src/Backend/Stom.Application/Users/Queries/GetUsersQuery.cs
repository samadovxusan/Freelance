using MediatR;
using Stom.Domain.Entities;

namespace Stom.Application.Users.Queries;

public class GetUsersQuery:IRequest<ICollection<User>>
{
    
}