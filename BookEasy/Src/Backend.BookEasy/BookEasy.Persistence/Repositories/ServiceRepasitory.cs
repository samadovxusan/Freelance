using BookEasy.Domain.Entities;
using BookEasy.Persistence.DataContext;
using BookEasy.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.Repositories;

public class ServiceRepasitory(AppDbContext context, DbSet<Service> dbSet) :EntityRepositoryBase<Service>(context, dbSet),IService
{
    
}