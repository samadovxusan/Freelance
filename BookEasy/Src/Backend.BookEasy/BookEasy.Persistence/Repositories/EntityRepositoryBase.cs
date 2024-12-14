using BookEasy.Persistence.DataContext;
using BookEasy.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.Repositories;

public class EntityRepositoryBase<T>(AppDbContext context,DbSet<T> dbSet):IEntityRepositoryBase<T> where T :class    
{
    public async ValueTask<T> GetByIdAsync(Guid id)
    {
        var result = await dbSet.FindAsync(id);
        return result;
    }

    public async ValueTask<ICollection<T>> GetAllAsync()
    {
        var result = await dbSet.ToListAsync();
        return result;
    }

    public async ValueTask<bool> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async ValueTask<T> UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async ValueTask<bool> DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}