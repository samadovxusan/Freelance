using AutoMapper;
using Stom.Application.Users.Models;
using Stom.Domain.Entities;

namespace Stom.Infrastructure.Users.Mappers;

public class UserMapper:Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}