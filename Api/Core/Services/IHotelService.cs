using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
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
