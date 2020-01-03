using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RoomTypeRoomFeatureEntity
    {
        public int Feature { get; set; }
        public int RoomType { get; set; }
        public string Description { get; set; }

        public virtual RoomFeatureEntity FeatureNavigation { get; set; }
        public virtual RoomTypeEntity RoomTypeNavigation { get; set; }
    }
}
