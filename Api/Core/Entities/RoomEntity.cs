using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RoomEntity
    {
        public RoomEntity()
        {
            Bookings = new HashSet<BookingEntity>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }

        public virtual RoomTypeEntity TypeNavigation { get; set; }
        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
