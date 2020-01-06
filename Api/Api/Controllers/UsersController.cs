using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModels;
using AutoMapper;
using Core.DTO;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;
        private IMapper _mapper;
        
        public UsersController(IUsersService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }

        // GET api/<controller>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _userService.GetByNameAsync(name);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserViewModel user)
        {
            var result = await _userService.CreateAsync(_mapper.Map<UserDTO>(user));
            return Created($"/api/auth/{result.Name}", result);
        }

        // PUT api/<controller>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]UserViewModel user)
        {
            var dto = _mapper.Map<UserDTO>(user);
            dto.Name = name;
            var result = await _userService.UpdateAsync(_mapper.Map<UserDTO>(user));
            if (result != null)
                return NoContent();
            else
                return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var result = await _userService.DeleteAsync(name);
            if (result != null)
                return NoContent();
            else
                return NotFound();
        }
    }
}
