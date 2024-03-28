using Application.Users.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Mappers;

public class UserMapper:Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
    
}