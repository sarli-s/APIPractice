using Entities;
using Repositories;

namespace Serveres
{
    public class UserServer
    {
        private readonly userRepositiory repositiory = new userRepositiory();

        public User GetUserById(int id)
        {
            return repositiory.GetUserById(id);
        }

        public User AddUser(User user)
        {
            return repositiory.AddUser(user);
        }

        public void UpdateUserDetails(int id, User value)
        {
            repositiory.UpdateUserDetails(id, value);
        }

        public User Login(LoginUser UserR)
        {
            return repositiory.Login(UserR);
        }
    }

}
