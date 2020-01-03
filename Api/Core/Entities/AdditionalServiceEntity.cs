using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class AdditionalServiceEntity
    {
        public AdditionalServiceEntity()
        {
            BookingServices = new HashSet<BookingServiceEntity>();
        }

        public int Id { get; set; }
        public int Hotel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual HotelEntity HotelNavigation { get; set; }
        public virtual ICollection<BookingServiceEntity> BookingServices { get; set; }
    }
}
