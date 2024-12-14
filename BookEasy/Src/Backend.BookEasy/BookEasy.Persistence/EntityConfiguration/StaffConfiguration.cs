using BookEasy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookEasy.Persistence.EntityConfiguration;

public class StaffConfiguration:IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        // Primary Key
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Specialty)
            .IsRequired()
            .HasMaxLength(50);

        // Relatsiyalar
        builder.HasMany(s => s.Bookings)
            .WithOne(b => b.Staff)
            .HasForeignKey(b => b.StaffId);
        
    }
}