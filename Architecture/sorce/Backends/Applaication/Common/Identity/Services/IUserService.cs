using System.Linq.Expressions;
using Domain.Entities;

namespace Applaication.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get (Expression<Func<User, bool>>? predicate = null);
    
    ValueTask<User?> GetByIdAsync (Guid id , CancellationToken cancellationToken = default);
    
    ValueTask<User> CreateAsync (User user, bool saveChanges =true ,CancellationToken cancellationToken = default);
    
    ValueTask<User> UpdateAsync (User user, bool saveChanges =true ,CancellationToken cancellationToken = default);
    
    ValueTask<User> DeleteAsync (User user, bool saveChanges =true ,CancellationToken cancellationToken = default);
}