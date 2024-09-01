using AutoMapper;
using Crm.Application.User.Madels;
using Crm.Application.User.Services;
using Crm.Application.Users.Queries;
using Xunarmand.Domain.Common.Queries;

namespace Crm.Infrastructure.Users.QueriesHandlers;

public class UserGetByIdQuerisHandler(IUserService service,IMapper mapper):IQueryHandler<UserGetByIdQueries,UserDto>
{
    public async Task<UserDto> Handle(UserGetByIdQueries request, CancellationToken cancellationToken)
    {
        var foundUser = await service.GetByIdAsync(
            request.Id, new QueryOptions(QueryTrackingMode.AsNoTracking), cancellationToken
        );
        return mapper.Map<UserDto>(foundUser);
    }
}