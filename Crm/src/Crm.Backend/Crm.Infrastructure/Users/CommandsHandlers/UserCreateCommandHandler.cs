using AutoMapper;
using Crm.Application.User.Madels;
using Crm.Application.User.Services;
using Crm.Application.Users.Commands;
using Crm.Domain.Entities;
using Xunarmand.Domain.Common.Commands;

namespace Crm.Infrastructure.Users.CommandsHandlers;

public class UserCreateCommandHandler(IUserService userService, IMapper mapper):ICommandHandler<UserCreateCommand, UserDto>
{
    public async Task<UserDto> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<User>(request.UserDto);
        var createdUser = await userService.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<UserDto>(createdUser);
    }
}