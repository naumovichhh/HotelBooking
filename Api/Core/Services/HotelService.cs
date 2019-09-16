using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Entities;

namespace Core.Services
{
    public class HotelService : IHotelService
    {
        private List<HotelEntity> hotels = new List<HotelEntity>()
        {
            new HotelEntity(1, "CITYHOTEL", "Kreschatik, 43", "Kyiv", "Ukraine", "hotel.jpg"),
            new HotelEntity(2, "Hotel du Parc", "Verbier, 10, 34", "Montelimar", "France", "hotel.jpg")
        };

        private IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public HotelService()
        {
        }

        public IEnumerable<HotelEntity> GetAll() => hotels;

        public HotelEntity GetById(int id) => hotels.Find(h => h.Id == id);

        public HotelEntity Create(HotelEntity hotel)
        {
            hotels.Add(hotel);
            return hotel;
        }

        public HotelEntity Update(HotelEntity hotel)
        {
            int index = hotels.FindIndex(h => h.Id == hotel.Id);
            if (index != -1)
            {
                hotels[index] = hotel;
                return hotel;
            }
            else
                return null;
        }

        public HotelEntity Delete(int id)
        {
            int index = hotels.FindIndex(h => h.Id == id);
            if (index != -1)
            {
                var hotel = hotels[index];
                hotels.RemoveAt(index);
                return hotel;
            }
            else
                return null;
        }
    }
}
