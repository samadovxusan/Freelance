using System.Linq.Expressions;
using Stom.Domain.Entities;
using Stom.Persistence.DbContexts;
using Stom.Persistence.Repositories.Interface;

namespace Stom.Persistence.Repositories;

public class UserRepository(AppDbContext appDbContext):EntityRepositoryBase<User, AppDbContext>(appDbContext),IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default)
    {
        return base.Get(predicate);
    }

    public ValueTask<User?> GetByIdAsync(Guid clientId, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(clientId, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid clientId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(clientId,cancellationToken);
    }
}