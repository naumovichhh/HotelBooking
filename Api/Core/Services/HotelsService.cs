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

        public IEnumerable<HotelDTO> GetAll() => _mapper.Map<IEnumerable<HotelDTO>>(_hotelRepository.GetAll());

        public HotelDTO GetById(int id) => _mapper.Map<HotelDTO>(_hotelRepository.GetById(id));

        public HotelDTO Create(HotelDTO hotel) => _mapper.Map<HotelDTO>(_hotelRepository.Create(_mapper.Map<HotelEntity>(hotel)));

        public HotelDTO Update(HotelDTO hotel) => _mapper.Map<HotelDTO>(_hotelRepository.Update(_mapper.Map<HotelEntity>(hotel)));

        public HotelDTO Delete(int id) => _mapper.Map<HotelDTO>(_hotelRepository.Delete(id));
    }
}
