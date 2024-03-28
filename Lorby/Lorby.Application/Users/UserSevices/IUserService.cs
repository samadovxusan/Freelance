using Application.Users.Models;
using Domain.Entities;

namespace Application.Users.UserSevices;

public interface IUserService
{
    ValueTask<IEnumerable<User>> GetUsers(User user);
    ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    ValueTask<User> CreateAsync(UserDto user,  CancellationToken cancellationToken = default);
    ValueTask<User> UpdateAsync(UserDto user,  CancellationToken cancellationToken = default);
    ValueTask<User> DeleteAsync(Guid id,  CancellationToken cancellationToken = default);

}