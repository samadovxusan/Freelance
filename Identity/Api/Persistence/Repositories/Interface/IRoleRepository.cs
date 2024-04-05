using System.Linq.Expressions;
using Domain.Common.Entities;

namespace Persistence.Repositories.Interface;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);
}