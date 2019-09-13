using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Services
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAll();
        Hotel GetById(int id);
        Hotel Create(Hotel hotel);
        Hotel Update(Hotel hotel);
        Hotel Delete(int id);
    }
}
