﻿using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.DataContext;

namespace Persistence.Repositories;

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
    /// Checks if entity exists
    /// </summary>
    /// <param name="entityId">Entity id to check</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if entity exists, otherwise false</returns>
    protected async ValueTask<bool> CheckByIdAsync(Guid entityId, CancellationToken cancellationToken = default)
    {
        var foundEntity = await DbContext.Set<TEntity>()
                                         .Select(entity => entity.Id)
                                         .FirstOrDefaultAsync(foundEntityId => foundEntityId == entityId,
                                             cancellationToken);

        return foundEntity != Guid.Empty;
    }

    /// <summary>
    /// Asynchronously retrieves entities from the repository by a collection of IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="queryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => ids.Contains(entity.Id));
        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
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
        await DbContext.SaveChangesAsync();
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


    /// <summary>
    /// Batch updates entities matching given predicate using the provided property selectors and value selectors.
    /// </summary>
    /// <param name="batchUpdatePredicate">Predicate to select entities for batch update</param>
    /// <param name="setPropertyCalls">Batch update value selectors</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of updated rows.</returns>
    protected async ValueTask<int> UpdateBatchAsync(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls,
        Expression<Func<TEntity, bool>>? batchUpdatePredicate = default,
        CancellationToken cancellationToken = default
    )
    {
        var entities = DbContext.Set<TEntity>().AsQueryable();

        if (batchUpdatePredicate is not null)
            entities = entities.Where(batchUpdatePredicate);

        return await entities.ExecuteUpdateAsync(
            setPropertyCalls,
            cancellationToken
        );
    }
}