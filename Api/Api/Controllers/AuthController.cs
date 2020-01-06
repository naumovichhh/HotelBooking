using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.ViewModels;
using Core.Services;
using Core.DTO;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMapper _mapper;
        private IAuthService _service;

        public AuthController(IMapper mapper, IAuthService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserViewModel user)
        {
            var dto = _mapper.Map<UserDTO>(user);
            dto.Role = "user";
            string name = await _service.RegisterAsync(dto);
            if (name != null)
                return Ok();
            else
                return Conflict();
        }

        [HttpPost("register/admin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody]UserViewModel admin)
        {
            var dto = _mapper.Map<UserDTO>(admin);
            dto.Role = "admin";
            string name = await _service.RegisterAsync(dto);
            if (name != null)
                return Ok(name);
            else
                return Conflict();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string name, string password)
        {
            var userToken = await _service.LoginAsync(name, password);
            if (userToken != null)
                return Ok("userToken");
            else
                return Unauthorized();
        }
    }
}