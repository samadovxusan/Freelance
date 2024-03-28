using System.Linq.Expressions;
using Applaication.Common.Identity.Services;
using Domain.Entities;
using Persistence.DataContext;

namespace Infrastructure.Common.Identity.Services;

public class UserServices: IUserService
{
    private readonly AppDbContext _context;

    public UserServices(AppDbContext context)
    {
        _context = context;
    }


    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null)
    {
        return predicate != null ? _context.Users.Where(predicate) : _context.Users;
    }

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Users.FindAsync(id, cancellationToken);
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user,cancellationToken);
        if (saveChanges)
            await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        if (saveChanges)
            await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _context.Users.Remove(user);
        if (saveChanges)
            await _context.SaveChangesAsync(cancellationToken);
        return user;
       
    }
}

