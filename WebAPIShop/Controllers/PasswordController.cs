using Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serveres;

namespace WebAPIShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly PasswordServer _server = new PasswordServer();

        [HttpPost]
        public ActionResult<Password> Post([FromBody] Password password)
        {
            password = _server.CheckPassword(password.PasswordItself);
            return Ok(password);
        }
       




    }
}
