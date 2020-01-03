using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.DTO;

namespace Core.Services
{
    public interface IHotelsService
    {
        Task<IEnumerable<HotelDTO>> GetAllAsync();
        Task<HotelDTO> GetByIdAsync(int id);
        Task<HotelDTO> CreateAsync(HotelDTO hotel);
        Task<HotelDTO> UpdateAsync(HotelDTO hotel);
        Task<HotelDTO> DeleteAsync(int id);
    }
}
