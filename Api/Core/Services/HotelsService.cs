using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Repositories;
using Core.Entities;

namespace Core.Services
{
    public class HotelsService : IHotelsService
    {
        private IHotelsRepository _hotelsRepository;
        private IMapper _mapper;

        public HotelsService(IHotelsRepository hotelsRepository, IMapper mapper)
        {
            _hotelsRepository = hotelsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HotelDTO>> GetBySearchAsync(string country, string locality, DateTime from, DateTime to, int adult, int child)
        {
            var all = await _hotelsRepository.GetAllAsync();
            var result = all.Where(h =>
            {
                if (h.Country != country || h.Locality != locality)
                    return false;
                var any = h.RoomTypes.Where(t => t.AdultPlaces >= adult && t.ChildPlaces >= child).SelectMany(t => t.Rooms)
                    .Any(r => r.Bookings.All(b => b.To < from || b.From > to));
                if (any) return true;
                else return false;
            });
            return _mapper.Map<List<HotelDTO>>(result);
        }

        public async Task<IEnumerable<HotelDTO>> GetAllAsync() => _mapper.Map<List<HotelDTO>>(await _hotelsRepository.GetAllAsync());

        public async Task<HotelDTO> GetByIdAsync(int id) => _mapper.Map<HotelDTO>(await _hotelsRepository.GetByIdAsync(id));

        public async Task<HotelDTO> CreateAsync(HotelDTO hotel) => _mapper.Map<HotelDTO>(await _hotelsRepository.CreateAsync(_mapper.Map<HotelEntity>(hotel)));

        public async Task<HotelDTO> UpdateAsync(HotelDTO hotel) => _mapper.Map<HotelDTO>(await _hotelsRepository.UpdateAsync(_mapper.Map<HotelEntity>(hotel)));

        public async Task<HotelDTO> DeleteAsync(int id) => _mapper.Map<HotelDTO>(await _hotelsRepository.DeleteAsync(id));
    }
}
