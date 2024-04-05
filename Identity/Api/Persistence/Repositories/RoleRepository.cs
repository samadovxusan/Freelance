using System.Linq.Expressions;
using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
using Persistence.Repositories.Interface;

namespace Persistence.Repositories;

public class RoleRepository:EntityBaseRepository<Role, AppDbContext>,IRoleRepository
{
    public RoleRepository(DbContext dbContext) : base(dbContext)
    {
        
    }
    public new IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }
}