using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Serveres
{
    public class PasswordServer
    {
        public Password CheckPassword(string passwordValue)
        {
            Password password = new Password();
            password.PasswordItself = passwordValue;
            var result = Zxcvbn.Core.EvaluatePassword(password.PasswordItself);
            password.Level = result.Score;
            return password;
        }
    }
}
