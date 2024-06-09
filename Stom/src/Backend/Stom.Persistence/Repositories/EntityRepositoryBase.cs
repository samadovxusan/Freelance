using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stom.Domain.Common.Entities;

namespace Stom.Persistence.Repositories;

/// <summary>
/// Represents a base repository for entities with common CRUD operations.
/// </summary>
/// <param name="dbContext"></param>
/// <param name="cacheBroker"></param>
/// <param name="cacheEntryOptions"></param>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TContext"></typeparam>
public abstract class EntityRepositoryBase<TEntity, TContext>(
    TContext dbContext)
    where TEntity : class, IEntity where TContext : DbContext
{
   
    protected TContext DbContext => dbContext;
    /// <summary>
    /// Retrieves entities from the repository based on optional filtering conditions and tracking preferences.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    /// <summary>
    /// Retrieves entities from the repository based on optional filtering conditions and tracking preferences.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="queryOptions">Additional query options</param>
    /// <returns></returns>
    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        return initialQuery;
    }
    
    /// <summary>
    /// Asynchronously retrieves an entity from the repository by its ID, optionally applying caching.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="queryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var foundEntity = default(TEntity?);
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();
        foundEntity = await initialQuery.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        return foundEntity;
    }


    /// <summary>
    /// Asynchronously creates a new entity in the repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity> CreateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken); 
        await DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Asynchronously updates a new entity in the repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        DbContext.Set<TEntity>().Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    /// <summary>
    /// Asynchronously deletes a new entity in the repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
        protected async ValueTask<TEntity?> DeleteAsync(
            TEntity entity,
            CancellationToken cancellationToken = default
        )
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

    /// <summary>
    /// Asynchronously deletes an existing entity from the repository by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    protected async ValueTask<TEntity?> DeleteByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await DbContext
                         .Set<TEntity>()
                         .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) 
                     ?? throw new InvalidOperationException();

        DbContext.Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}