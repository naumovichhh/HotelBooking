using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HotelsRepository : IHotelsRepository
    {
        private DefaultContext _context;

        public HotelsRepository(DefaultContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<HotelEntity>> GetAllAsync() => await _context.Hotels.ToListAsync();

        public async Task<HotelEntity> GetByIdAsync(int id) => await _context.Hotels.FindAsync(id);

        public async Task<HotelEntity> CreateAsync(HotelEntity hotel)
        {
            var result = (await _context.Hotels.AddAsync(hotel)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<HotelEntity> UpdateAsync(HotelEntity hotel)
        {
            HotelEntity found = await _context.Hotels.FindAsync(hotel.Id);
            if (found != null) return null;

            var entry = _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<HotelEntity> DeleteAsync(int id)
        {
            var entity = await _context.Hotels.FindAsync(id);
            if (entity == null)
                return null;
            var result = _context.Hotels.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
