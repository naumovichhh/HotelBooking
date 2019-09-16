using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services
{
    public interface IHotelService
    {
        IEnumerable<HotelEntity> GetAll();
        HotelEntity GetById(int id);
        HotelEntity Create(HotelEntity hotel);
        HotelEntity Update(HotelEntity hotel);
        HotelEntity Delete(int id);
    }
}
