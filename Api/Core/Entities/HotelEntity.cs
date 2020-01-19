using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class HotelEntity
    {
        public HotelEntity()
        {
            AdditionalServices = new HashSet<AdditionalServiceEntity>();
            RoomTypes = new HashSet<RoomTypeEntity>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Stars { get; set; }

        public virtual ICollection<AdditionalServiceEntity> AdditionalServices { get; set; }
        public virtual ICollection<RoomTypeEntity> RoomTypes { get; set; }
    }
}
