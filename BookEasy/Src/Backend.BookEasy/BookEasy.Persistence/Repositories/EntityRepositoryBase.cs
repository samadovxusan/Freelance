using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.Repositories;

public class EntityRepositoryBase<TEntity, TContext> where TEntity : class where TContext:DbContext
{
    private readonly TContext _context;
    public EntityRepositoryBase(TContext context) => _context = context;
    
    public async ValueTask<TEntity> Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async ValueTask<TEntity> Get(Guid Id)
    {
        var get = await _context.Set<TEntity>().FindAsync(Id);
        return get;
    }

    public async ValueTask<TEntity> Delete(Guid id)
    {
        var get = await _context.Set<TEntity>().FindAsync(id);
        _context.Set<TEntity>().Remove(get);
        await _context.SaveChangesAsync();
        return get;


    }

    public async ValueTask<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async ValueTask<TEntity> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async ValueTask<TEntity> Update(int id, TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    
}