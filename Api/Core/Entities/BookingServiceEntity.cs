using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class BookingServiceEntity
    {
        public int Booking { get; set; }
        public int Service { get; set; }

        public virtual BookingEntity BookingNavigation { get; set; }
        public virtual AdditionalServiceEntity ServiceNavigation { get; set; }
    }
}
