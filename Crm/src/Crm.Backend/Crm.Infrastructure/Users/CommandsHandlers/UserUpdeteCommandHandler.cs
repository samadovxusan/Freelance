using AutoMapper;
using Crm.Application.User.Madels;
using Crm.Application.User.Services;
using Crm.Application.Users.Commands;
using Crm.Domain.Entities;
using Xunarmand.Domain.Common.Commands;

namespace Crm.Infrastructure.Users.CommandsHandlers;

public class UserUpdeteCommandHandler(IUserService service , IMapper mapper):ICommandHandler<UserUpdateCommand, UserDto>
{
    public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<User>(request.UserDto);
        
        var updateUser = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        
        return mapper.Map<UserDto>(updateUser);
    }
}