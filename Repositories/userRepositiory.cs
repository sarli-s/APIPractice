using System.Text.Json;
using Entities;

namespace Repositories
{
    public class userRepositiory
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

        public User GetUserById(int id)
        {
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
            return null;
        }

        public User AddUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);

            return  user;
        }


        public User Login(LoginUser UserR)
{

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userT = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userT.UserEmail == UserR.LoginUserEmail && userT.UserPassword == UserR.LoginUserPassword)
                        return userT;
                }
            }
            return null;   /////
        }

        public void UpdateUserDetails(int id, User value)
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
    }
}
