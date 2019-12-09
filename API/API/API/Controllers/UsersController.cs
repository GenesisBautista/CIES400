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
        // GET: /Users/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(string id)
        {
            Users foundUser = new Users();
            foundUser.findById(id);
            if(!string.IsNullOrEmpty(foundUser.id))
            {
                return foundUser;
            }
            else
            {
                return NotFound();
            }
        }

        // POST: /Users
        [HttpPost]
        public object Post([FromBody] Dictionary<string, string> pairs)
        {
            Users newUser = new Users();

            return newUser.createUser(
                pairs["id"],
                pairs["username"],
                pairs["password"],
                pairs["hint"],
                pairs["firstName"],
                pairs["lastName"],
                Convert.ToDateTime(pairs["birthDate"]),
                int.Parse(pairs["userType"])
                );
        }

        // POST: /Users/login
        [HttpPost("login")]
        public object login([FromBody] Dictionary<string, string> pairs)
        {
            Users possibleUser = new Users();
            string result = possibleUser.login(pairs["username"], pairs["password"]);
            switch (result)
            {
                case "Error: User already logged in":
                    return Conflict();
                case "Error: Bad Credentials":
                    return Unauthorized();
                default:
                    return possibleUser;
            };
        }

        // POST: /Users/logout
        [HttpPost("logout")]
        public void logout([FromBody] Dictionary<string, string> pairs)
        {
            Users user = new Users();
            user.logout(pairs["sessionId"]);
        }
    }
}
