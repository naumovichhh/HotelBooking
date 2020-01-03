using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IRoomsRepository
    {
        Task<RoomEntity> GetByIdAsync(int id);

        Task<IEnumerable<RoomEntity>> GetAllAsync();

        Task<RoomEntity> CreateAsync(RoomEntity room);

        Task<RoomEntity> UpdateAsync(RoomEntity room);

        Task<RoomEntity> DeleteAsync(int id);
    }
}
