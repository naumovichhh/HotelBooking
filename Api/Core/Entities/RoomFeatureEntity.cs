using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RoomFeatureEntity
    {
        public RoomFeatureEntity()
        {
            RoomTypeRoomFeatures = new HashSet<RoomTypeRoomFeatureEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoomTypeRoomFeatureEntity> RoomTypeRoomFeatures { get; set; }
    }
}
