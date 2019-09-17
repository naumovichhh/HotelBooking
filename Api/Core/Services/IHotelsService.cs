using System.Collections.Generic;
using Core.Entities;
using Core.DTO;

namespace Core.Services
{
    public interface IHotelsService
    {
        IEnumerable<HotelDTO> GetAll();
        HotelDTO GetById(int id);
        HotelDTO Create(HotelDTO hotel);
        HotelDTO Update(HotelDTO hotel);
        HotelDTO Delete(int id);
    }
}
