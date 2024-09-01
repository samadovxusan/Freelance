using System.Linq.Expressions;
using Crm.Application.User.Madels;
using Crm.Application.User.Services;
using Crm.Domain.Entities;
using Crm.Persistence.Extensions;
using Crm.Persistence.Repasitory.Inteface;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;

namespace Crm.Infrastructure.Users.Services;

public class UserServices(IUserRepository userRepository):IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, QueryOptions queryOptions = default)
    {
        return userRepository.Get(predicate, queryOptions);
    }

    public IQueryable<User> Get(UserFilter clientFilter, QueryOptions queryOptions = default)
    {
        return userRepository.Get(queryOptions: queryOptions).ApplyPagination(clientFilter);
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, QueryOptions queryOptions = default, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(userId, queryOptions, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, new CommandOptions(skipSaveChanges: false), cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var foundUser = GetByIdAsync(user.Id, cancellationToken: cancellationToken).Result?? throw new InvalidOperationException();
        foundUser.Name = user.Name;
        foundUser.Address = user.Address;
        foundUser.Email = user.Email;
        foundUser.ImagePath = user.ImagePath;
        return userRepository.UpdateAsync(foundUser, new CommandOptions(skipSaveChanges: false), cancellationToken);
        
    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(userId, commandOptions, cancellationToken);
    }
}