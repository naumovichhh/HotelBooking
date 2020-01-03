using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class BookingEntity
    {
        public BookingEntity()
        {
            BookingServices = new HashSet<BookingServiceEntity>();
        }

        public int Id { get; set; }
        public int Room { get; set; }
        public string User { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual RoomEntity RoomNavigation { get; set; }
        public virtual UserEntity UserNavigation { get; set; }
        public virtual ICollection<BookingServiceEntity> BookingServices { get; set; }
    }
}
