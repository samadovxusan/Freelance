using System.Linq.Expressions;
using Application.Users.Models;
using Application.Users.UserSevices;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
using Persistence.Repositories.Interface;

namespace Infrastructure.Users;

public class UserService(IMapper mapper, IUserRepository userRepository ,AppDbContext appDbContext ): IUserService
{
    public async ValueTask<IEnumerable<User>> GetUsers()
    {

        return await appDbContext.Users.ToListAsync();

    }

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(id, cancellationToken);
    }

    public ValueTask<User> CreateAsync(UserDto user, string imageUrl, CancellationToken cancellationToken = default)
    {
        var result = mapper.Map<User>(user);
        result.ImageUrl = imageUrl;
        return userRepository.CreateAsync(result, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(UserDto userDto, Guid id, CancellationToken cancellationToken = default)
    {
        var finduser = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        
        finduser.Name = userDto.Name;
        finduser.Email = userDto.Email;
        finduser.Password = userDto.Password;

        var result  = await userRepository.UpdateAsync(finduser, cancellationToken);
        return result;
    }

  


    public  ValueTask<User> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(id, cancellationToken);
    }
}