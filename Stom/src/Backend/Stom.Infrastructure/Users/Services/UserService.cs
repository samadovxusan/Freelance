using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Stom.Application.Users.Services;
using Stom.Domain.Entities;
using Stom.Persistence.DbContexts;
using Stom.Persistence.Repositories.Interface;

namespace Stom.Infrastructure.Users.Services;

public class UserService(IUserRepository userRepository,AppDbContext appDbContext):IUserService
{
    public  IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default)
    {
        return userRepository.Get(predicate);
    }

    public async ValueTask<ICollection<User>> GetAll()
    {
        return await appDbContext.Users.ToListAsync();
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(userId, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        var foundClient = await GetByIdAsync(user.Id, cancellationToken: cancellationToken) ??
                          throw new InvalidOperationException();

        foundClient.Name = user.Name;
        foundClient.Email = user.Email;
        foundClient.Age = user.Age;
        foundClient.ImageUrl = user.ImageUrl;

        return await userRepository.UpdateAsync(foundClient, cancellationToken);

    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(userId, cancellationToken);
    }
}