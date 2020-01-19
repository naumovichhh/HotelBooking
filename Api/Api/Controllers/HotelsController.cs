using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModels;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private IHotelsService _hotelsService;
        private IMapper _mapper;

        public HotelsController(IHotelsService hotelsService, IMapper mapper)
        {
            _hotelsService = hotelsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string country, string locality, DateTime from, DateTime to, int adult, int child)
        {
            return Ok(await _hotelsService.GetBySearchAsync(country, locality, from, to, adult, child));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _hotelsService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HotelViewModel hotel)
        {
            HotelDTO result = await _hotelsService.CreateAsync(_mapper.Map<HotelDTO>(hotel));
            return Created($"/api/hotels/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]HotelViewModel hotel)
        {
            HotelDTO dto = _mapper.Map<HotelDTO>(hotel);
            dto.Id = id;
            var result = await _hotelsService.UpdateAsync(dto);
            if (result != null)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hotelsService.DeleteAsync(id);
            if (result != null)
                return NoContent();
            else
                return NotFound();
        }
    }
}
