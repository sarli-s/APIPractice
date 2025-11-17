using Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serveres;

namespace WebAPIShop.Controllers
{
    public class PasswordController : Controller
    {

        PasswordServer server = new PasswordServer();

        //[Route("api/[controller]")]

        //[HttpGet]
        //public ActionResult<Password> Get()
        //{
        //    Password password = new Password() { PasswordItself = "123" };
        //    if (password != null)
        //    {
        //        return Ok(password);
        //    }
        //    return NoContent();
        //}
        [Route("api/[controller]")]

        [HttpPost]
        public ActionResult<Password> Post([FromBody] Password password)
        {
            password= server.checkPassword(password.PasswordItself);
            return Ok(password);
            //Password creatingPassword = password;

            //return CreatedAtAction(nameof(Get), new
            //{
            //    id = creatingPassword.PasswordItself
            //}, creatingPassword);
        }
       




    }
}
