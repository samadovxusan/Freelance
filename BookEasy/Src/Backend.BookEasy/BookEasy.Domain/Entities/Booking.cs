using BookEasy.Domain.Common.Entities;

namespace BookEasy.Domain.Entities;

public class Booking:AuditableEntity
{
        public Guid UserId { get; set; } // Foydalanuvchi ID
        public User User { get; set; } // Foydalanuvchi obyektiga havola

      
        public Guid StaffId { get; set; } // Xodim ID
        public Staff Staff { get; set; } // Xodim obyektiga havola

        // Service bilan bog'lanish
        public Guid ServiceId { get; set; } // Xizmat ID
        public Service Service { get; set; } // Xizmat obyektiga havola

        // Bron vaqti
        public DateTime Date { get; set; } // Bron qilingan sana
        public TimeSpan Time { get; set; } // Bron qilingan vaqt

}