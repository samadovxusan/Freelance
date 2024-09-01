using AutoMapper;
using Crm.Application.User.Madels;
using Crm.Application.User.Services;
using Crm.Application.Users.Queries;
using Microsoft.EntityFrameworkCore;
using Xunarmand.Domain.Common.Queries;

namespace Crm.Infrastructure.Users.QueriesHandlers;

public class UserGerQuriesHandler(IUserService service,IMapper mapper):IQueryHandler<UserGetQueries,ICollection<UserDto>>
{
    public async Task<ICollection<UserDto>> Handle(UserGetQueries request, CancellationToken cancellationToken)
    {
        var matchedUsers = await service
            .Get(request.Filter, new QueryOptions() { TrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<UserDto>>(matchedUsers);
    }
} 