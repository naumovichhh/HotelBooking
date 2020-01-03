using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RoomTypeEntity
    {
        public RoomTypeEntity()
        {
            Rooms = new HashSet<RoomEntity>();
            RoomTypeRoomFeatures = new HashSet<RoomTypeRoomFeatureEntity>();
        }

        public int Id { get; set; }
        public int Hotel { get; set; }
        public int AdultPlaces { get; set; }
        public int ChildPlaces { get; set; }
        public string BedsDescription { get; set; }
        public string Name { get; set; }

        public virtual HotelEntity HotelNavigation { get; set; }
        public virtual ICollection<RoomEntity> Rooms { get; set; }
        public virtual ICollection<RoomTypeRoomFeatureEntity> RoomTypeRoomFeatures { get; set; }
    }
}
