using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Repositories
{
    public interface IHotelsRepository
    {
        IEnumerable<HotelEntity> GetAll();

        HotelEntity GetById(int id);

        HotelEntity Create(HotelEntity hotel);

        HotelEntity Update(HotelEntity hotel);

        HotelEntity Delete(int id);
    }
}
