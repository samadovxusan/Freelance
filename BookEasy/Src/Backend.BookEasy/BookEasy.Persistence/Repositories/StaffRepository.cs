using BookEasy.Domain.Entities;
using BookEasy.Persistence.DataContext;
using BookEasy.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.Repositories;

public class StaffRepository(AppDbContext context, DbSet<Staff> dbSet) :EntityRepositoryBase<Staff>(context, dbSet),IStaff
{
    
}