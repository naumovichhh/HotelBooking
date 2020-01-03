using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Repositories
{
    public interface IRoomsRepository
    {
        RoomEntity Get(int id);

        IEnumerable<RoomEntity> Get();

        RoomEntity Create(RoomEntity room);

        RoomEntity Update(RoomEntity room);

        RoomEntity Delete(int id);
    }
}
