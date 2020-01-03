using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController()
        {

        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IAsyncResult> Get()
        {
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IAsyncResult> Get(int id)
        {
            return 
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
