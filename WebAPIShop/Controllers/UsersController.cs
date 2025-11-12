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

        UserServer server = new UserServer();

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
      
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) {
            User user =server.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NoContent(); 
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
                return CreatedAtAction(nameof(Get), new { id = loginUser.UserId }, loginUser);
            }

            return NoContent();  
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            server.UpdateUserDetails(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            server.DeleteUser(id);
        }
    }
}
