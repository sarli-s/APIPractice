using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIShop.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //string filePath= "M:\\WebApi\\daf.txt";
        string filePath = "C:\\Users\\תמר שפריי\\Documents\\שרלי לימודים\\סופי\\users.txt";// "C:\\Users\\user\\Desktop\\daf.txt";
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
      
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return NoContent();   /////
        }
  
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new
            {
                id = user.UserId
            }, user);
        }


        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] LoginUser UserR)
        {

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userT = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userT.UserEmail == UserR.LoginUserEmail && userT.UserPassword == UserR.LoginUserPassword)
                        return CreatedAtAction(nameof(Get), new { id = userT.UserId }, userT);
                }
            }
            return NoContent();   /////
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(value));
                System.IO.File.WriteAllText(filePath, text);
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
