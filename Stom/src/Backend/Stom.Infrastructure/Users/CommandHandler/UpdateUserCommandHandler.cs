using AutoMapper;
using MediatR;
using Stom.Application.Users.Commands;
using Stom.Application.Users.Models;
using Stom.Application.Users.Services;
using Stom.Domain.Entities;

namespace Stom.Infrastructure.Users.CommandHandler;

public class UpdateUserCommandHandler(IUserService service,IMapper mapper):IRequestHandler<UpdateUserCommand,UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<User>(request.UserDto);

        var updateUser = await service.UpdateAsync(entity, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(updateUser);
    }
}