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
        private IHotelsRepository _hotelRepository;
        private IMapper _mapper;

        public HotelsService(IHotelsRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HotelDTO>> GetAllAsync() => _mapper.Map<List<HotelDTO>>(await _hotelRepository.GetAllAsync());

        public async Task<HotelDTO> GetByIdAsync(int id) => _mapper.Map<HotelDTO>(await _hotelRepository.GetByIdAsync(id));

        public async Task<HotelDTO> CreateAsync(HotelDTO hotel) => _mapper.Map<HotelDTO>(await _hotelRepository.CreateAsync(_mapper.Map<HotelEntity>(hotel)));

        public async Task<HotelDTO> UpdateAsync(HotelDTO hotel) => _mapper.Map<HotelDTO>(await _hotelRepository.UpdateAsync(_mapper.Map<HotelEntity>(hotel)));

        public async Task<HotelDTO> DeleteAsync(int id) => _mapper.Map<HotelDTO>(await _hotelRepository.DeleteAsync(id));
    }
}
