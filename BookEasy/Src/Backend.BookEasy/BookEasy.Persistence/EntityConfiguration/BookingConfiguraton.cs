using BookEasy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookEasy.Persistence.EntityConfiguration;

public class BookingConfiguraton:IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        // Primary Key
        builder.HasKey(b => b.Id);

        // User bilan bog'lanish
        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Foydalanuvchi o'chsa, bronlar ham o'chadi

        // Staff bilan bog'lanish
        builder.HasOne(b => b.Staff)
            .WithMany(s => s.Bookings)
            .HasForeignKey(b => b.StaffId)
            .OnDelete(DeleteBehavior.Restrict); // Xodim o'chsa, bronlar saqlanadi

        // Service bilan bog'lanish
        builder.HasOne(b => b.Service)
            .WithMany() // Xizmat bir tomondan "ko'p"
            .HasForeignKey(b => b.ServiceId)
            .OnDelete(DeleteBehavior.Restrict); // Xizmat o'chsa, bronlar saqlanadi

        // Qo'shimcha maydonlar
        builder.Property(b => b.Date).IsRequired(); // Sana majburiy
        builder.Property(b => b.Time).IsRequired(); // Vaqt majburiy
    }
}