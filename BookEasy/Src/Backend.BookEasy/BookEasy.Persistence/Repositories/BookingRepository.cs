using BookEasy.Domain.Entities;
using BookEasy.Persistence.DataContext;
using BookEasy.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookEasy.Persistence.Repositories;

public class BookingRepository(AppDbContext context, DbSet<Booking> dbSet) :EntityRepositoryBase<Booking>(context, dbSet),IBooking

{
    
}