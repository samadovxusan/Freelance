using AutoMapper;
using MediatR;
using Stom.Application.Users.Commands;
using Stom.Application.Users.Models;
using Stom.Application.Users.Services;
using Stom.Domain.Entities;

namespace Stom.Infrastructure.Users.CommandHandler;

public  class CreateUserCommandHandler(IUserService userService, IMapper mapper):IRequestHandler<CreateUserCommand,UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await userService.CreateAsync(request.user, cancellationToken);

        return mapper.Map<UserDto>(result);
    }
}