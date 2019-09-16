using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Repositories
{
    public class HotelsRepository
    {
        private List<HotelEntity> _hotels = new List<HotelEntity>()
        {
            new HotelEntity(1, "Name", "Address", "Locality", "Country", "hotel.jpg")
        };

        public IEnumerable<HotelEntity> GetAll() => _hotels;

        public HotelEntity GetById(int id) => _hotels.Find(h => h.Id == id);

        public HotelEntity Create(HotelEntity hotel)
        {
            _hotels.Add(hotel);
            return hotel;
        }

        public HotelEntity Update(HotelEntity hotel)
        {
            int index = _hotels.FindIndex(h => h.Id == hotel.Id);
            if (index != -1)
            {
                _hotels[index] = hotel;
                return hotel;
            }
            else
                return null;
        }

        public HotelEntity Delete(int id)
        {
            int index = _hotels.FindIndex(h => h.Id == id);
            if (index != -1)
            {
                var hotel = _hotels[index];
                _hotels.RemoveAt(index);
                return hotel;
            }
            else
                return null;
        }
    }
}
