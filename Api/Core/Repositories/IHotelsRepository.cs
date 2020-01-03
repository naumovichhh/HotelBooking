using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IHotelsRepository
    {
        Task<IEnumerable<HotelEntity>> GetAllAsync();

        Task<HotelEntity> GetByIdAsync(int id);

        Task<HotelEntity> CreateAsync(HotelEntity hotel);

        Task<HotelEntity> UpdateAsync(HotelEntity hotel);

        Task<HotelEntity> DeleteAsync(int id);
    }
}
