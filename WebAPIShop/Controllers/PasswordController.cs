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

        private readonly PasswordServer server = new PasswordServer();

        [HttpPost]
        public ActionResult<Password> Post([FromBody] Password password)
        {
            password= server.checkPassword(password.PasswordItself);
            return Ok(password);
        }