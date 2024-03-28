using System.Linq.Expressions;
using Application.Users.Models;
using Application.Users.UserSevices;
using AutoMapper;
using Domain.Entities;
using Persistence.DataContext;
using Persistence.Repositories.Interface;

namespace Infrastructure.Users;

public class UserService(IMapper mapper, IUserRepository userRepository ,AppDbContext appDbContext ): IUserService
{
    public ValueTask<IEnumerable<User>> GetUsers( User user)
    {
        throw new NotImplementedException();
        
    }

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(id, cancellationToken);
    }

    public ValueTask<User> CreateAsync(UserDto user, CancellationToken cancellationToken = default)
    {
        var result = mapper.Map<User>(user);
        return userRepository.CreateAsync(result, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(UserDto user, CancellationToken cancellationToken = default)
    {
        var result = mapper.Map<User>(user);
        return userRepository.UpdateAsync(result, cancellationToken);
    }

    public  ValueTask<User> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(id, cancellationToken);
    }
}