using System.Linq.Expressions;
using EcoMarket.Persistencee.Repositories;
using Identity.Domain.Common.Commands;
using Identity.Domain.Common.Entities;
using Identity.Domain.Queries;
using Identity.Persistence.DataContext;
using Identity.Persistence.Repositories.Repositories.Interfaces;

namespace Identity.Persistence.Repositories.Repositories;

public class UserRepository(AppDbContext appDbContext ):EntityRepositoryBase<User,AppDbContext>(appDbContext),IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, QueryOptions queryOptions = default) 
        => base.Get(predicate,queryOptions);

    public ValueTask<User?> GetByIdAsync(Guid clientId, QueryOptions queryOptions = default, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(clientId,queryOptions, cancellationToken);

    public ValueTask<User> CreateAsync(User client,CommandOptions commandOptions = default, CancellationToken cancellationToken = default) 
        => base.CreateAsync(client, commandOptions,cancellationToken);

    public ValueTask<User> UpdateAsync(User client, CommandOptions commandOptions = default, CancellationToken cancellationToken = default) 
        => base.UpdateAsync(client,commandOptions, cancellationToken);

    public ValueTask<User?> DeleteByIdAsync(Guid clientId,CommandOptions commandOptions = default, CancellationToken cancellationToken = default) 
        => base.DeleteByIdAsync(clientId,commandOptions, cancellationToken);
}