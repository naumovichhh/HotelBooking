using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return _hotelService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return _hotelService.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Hotel hotel)
        {
            _hotelService.Create(hotel);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            _hotelService.Update();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _hotelService.Delete(id);
        }
    }
}
