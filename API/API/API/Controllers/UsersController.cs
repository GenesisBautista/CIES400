using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public Users Get(string id)
        {
            Users foundUser = new Users();
            foundUser.findById(id);
            return foundUser;
        }

        [HttpGet]
        [ActionName("test")]
        public string test()
        {
            return "test";
        }

        // POST: api/User
        [HttpPost]
        public object Post([FromBody] Dictionary<string, string> pairs)
        {
            Users foundUser = new Users();
            foundUser.findByUsername(pairs["username"]);
            if (foundUser.password == pairs["password"])
            {
                return foundUser;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public object login([FromBody] Dictionary<string, string> pairs)
        {
            Users foundUser = new Users();
            foundUser.findByUsername(pairs["username"]);
            if (foundUser.password == pairs["password"])
            {
                return foundUser;
            }
            else
            {
                return Unauthorized();
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
