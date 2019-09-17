using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class HotelsRepository : IHotelsRepository
    {
        private DefaultContext _context;

        public HotelsRepository(DefaultContext context)
        {
            this._context = context;
        }

        public IEnumerable<HotelEntity> GetAll() => _context.Hotel.ToList();

        public HotelEntity GetById(int id) => _context.Hotel.Find(id);

        public HotelEntity Create(HotelEntity hotel)
        {
            var result = _context.Hotel.Add(hotel).Entity;
            _context.SaveChanges();
            return result;
        }
        public HotelEntity Update(HotelEntity hotel)
        {
            HotelEntity existing = _context.Hotel.Find(hotel.Id);
            if (existing != null)
            {
                _context.Hotel.Update(hotel);
                _context.SaveChanges();
                return hotel;
            }
            else
                return null;
        }

        public HotelEntity Delete(int id)
        {
            var result = _context.Hotel.Remove(_context.Hotel.Find(id)).Entity;
            _context.SaveChanges();
            return result;
        }
    }
}
