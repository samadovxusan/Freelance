using BookEasy.Domain.Entities;
using BookEasy.Persistence.DataContext;
using BookEasy.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.Repositories;

public class UserRepository(AppDbContext context, DbSet<User> dbSet) :EntityRepositoryBase<User>(context, dbSet),IUser
{
    
}