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
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private IHotelsService _hotelsService;
        private IMapper _mapper;

        public HotelController(IHotelsService hotelsService, IMapper mapper)
        {
            _hotelsService = hotelsService;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hotelsService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_hotelsService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]HotelViewModel hotel)
        {
            HotelDTO result = _hotelsService.Create(_mapper.Map<HotelDTO>(hotel));
            return Created($"/api/hotels/{result.Id}", result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]HotelViewModel hotel)
        {
            return Accepted(_hotelsService.Update(_hotelsService.Create(_mapper.Map<HotelDTO>(hotel))));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _hotelsService.Delete(id);
            return NoContent();
        }
    }
}
