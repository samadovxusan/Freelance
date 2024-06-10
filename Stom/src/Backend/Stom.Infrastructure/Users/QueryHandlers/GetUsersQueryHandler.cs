using MediatR;
using Stom.Application.Users.Queries;
using Stom.Application.Users.Services;
using Stom.Domain.Entities;

namespace Stom.Infrastructure.Users.QueryHandlers;

public class GetUsersQueryHandler(IUserService service):IRequestHandler<GetUsersQuery,ICollection<User>>
{
    public async Task<ICollection<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await service.GetAll();
    }
}