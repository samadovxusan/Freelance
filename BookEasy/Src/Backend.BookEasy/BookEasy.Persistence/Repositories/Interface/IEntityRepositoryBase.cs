namespace BookEasy.Persistence.Repositories.Interface;

public interface IEntityRepositoryBase<T> where T :class
{
    ValueTask<T> GetByIdAsync(Guid id);
    ValueTask<ICollection<T>> GetAllAsync();
    ValueTask<bool> AddAsync(T entity);
    ValueTask<T> UpdateAsync(T entity);
    ValueTask<bool> DeleteAsync(T entity);
    
}