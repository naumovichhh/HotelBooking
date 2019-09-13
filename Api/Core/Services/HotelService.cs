using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Services
{
    public class HotelService : IHotelService
    {
        private List<Hotel> hotels = new List<Hotel>()
        {
            new Hotel(1, "CITYHOTEL", "Kreschatik, 43", "Kyiv", "Ukraine", "hotel.jpg"),
            new Hotel(2, "Hotel du Parc", "Verbier, 10, 34", "Montelimar", "France", "hotel.jpg")
        };

        public IEnumerable<Hotel> GetAll() => hotels;

        public Hotel GetById(int id) => hotels.Find(h => h.Id == id);

        public Hotel Create(Hotel hotel)
        {
            hotels.Add(hotel);
            return hotel;
        }

        public Hotel Update(Hotel hotel)
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

        public Hotel Delete(int id)
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
