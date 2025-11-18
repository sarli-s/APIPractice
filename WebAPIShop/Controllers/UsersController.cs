using Entities;
using Microsoft.AspNetCore.Mvc;
using Serveres;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServer _server = new UserServer();

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
      
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) {
            User user = _server.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound(); 
        }

  
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            User creatingUser = _server.AddUser(user);

            return CreatedAtAction(nameof(Get), new
            {
                id = creatingUser.UserId
            }, creatingUser);
        }


        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {
            User user = _server.Login(loginUser);
            if (user != null)
            {
                return Ok(user);
            }

            return Unauthorized();  
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            _server.UpdateUserDetails(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _server.DeleteUser(id);
        }
    }
}
