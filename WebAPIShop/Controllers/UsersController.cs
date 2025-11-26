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

        private readonly UserServer server = new UserServer();
      
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) {
            User user =server.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound(); 
        }

  
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            User creatingUser = server.AddUser(user);

            return CreatedAtAction(nameof(Get), new
            {
                id = creatingUser.UserId
            }, creatingUser);
        }


        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] LoginUser UserR)
        {

            User loginUser = server.Login(UserR);
            if (loginUser != null)
            {
                return Ok(loginUser);
            }

            return Unauthorized();  
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            server.UpdateUserDetails(id, value);
        }

    }
}
