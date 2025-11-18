using Entities;
using Repositories;

namespace Serveres
{
    public class UserServer
    {
        private readonly UserRepository _repository = new UserRepository();

        public User GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            return _repository.AddUser(user);
        }

        public void UpdateUserDetails(int id, User value)
        {
            _repository.UpdateUserDetails(id, value);
        }

        public User Login(LoginUser loginUser)
        {
            return _repository.Login(loginUser);
        }

        public void DeleteUser(int id)
        {
            _repository.DeleteUser(id);
        }
    }

}
