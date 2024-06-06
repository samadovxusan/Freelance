using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace StartUp.Persistence.Repository;

public abstract class BaseEntityRepository<TEntity, TContext>(TContext dbContext) where TEntity: class where TContext: DbContext
{
    protected TContext DbContext => dbContext;

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default)
    {
        var initialQuery = dbContext.Set<TEntity>().Where(entity => true);
        
        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        return initialQuery;
    }
    
    protected async ValueTask<TEntity?> GetByIdAsync(
        Expression<Func<TEntity, bool>> id,
        CancellationToken cancellationToken = default
    )
    {
        var foundEntity = default(TEntity?);
        
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();
            
        foundEntity = await initialQuery.FirstOrDefaultAsync(id, cancellationToken);
        
        return foundEntity;
    }
    protected async ValueTask<TEntity> CreateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
    protected async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        DbContext.Set<TEntity>().Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
    protected async ValueTask<TEntity?> DeleteAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        DbContext.Set<TEntity>().Remove(entity);
        
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}