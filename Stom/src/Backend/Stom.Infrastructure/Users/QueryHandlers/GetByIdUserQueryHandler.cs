using AutoMapper;
using MediatR;
using Stom.Application.Users.Models;
using Stom.Application.Users.Queries;
using Stom.Application.Users.Services;
using Stom.Domain.Entities;

namespace Stom.Infrastructure.Users.QueryHandlers;

public class GetByIdUserQueryHandler(IUserService service,IMapper mapper):IRequestHandler<GetByIdUserQuery,UserDto>
{
    public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.Id, cancellationToken);
        return  mapper.Map<UserDto>(result);

    }
}