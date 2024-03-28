using System.Linq.Expressions;
using Domain.Entities;
using Persistence.DataContext;
using Persistence.Repositories.Interface;

namespace Persistence.Repositories;

public class UserRepository(AppDbContext appDbContext ) :EntityRepositoryBase<User, AppDbContext>(appDbContext),IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default) =>
            base.Get(predicate);

    public ValueTask<User?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)=>
            base.GetByIdAsync(productId, cancellationToken);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)=>
            base.GetByIdsAsync(ids, cancellationToken);

    public ValueTask<User> CreateAsync(User user, CancellationToken cancellationToken = default) =>
            base.CreateAsync(user, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, CancellationToken cancellationToken = default)=>
    base.UpdateAsync(user, cancellationToken);
    
    public ValueTask<User?> DeleteByIdAsync(Guid productId, CancellationToken cancellationToken = default)=>
            base.DeleteByIdAsync(productId, cancellationToken);

    public ValueTask<User?> DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
            throw new NotImplementedException();
    }
}