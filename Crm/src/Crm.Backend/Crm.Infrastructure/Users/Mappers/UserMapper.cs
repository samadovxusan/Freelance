using AutoMapper;
using Crm.Application.User.Madels;
using Crm.Domain.Entities;

namespace Crm.Infrastructure.Users.Mappers;

public class UserMapper:Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
    
}