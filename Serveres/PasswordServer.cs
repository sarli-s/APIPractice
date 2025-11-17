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
        public Password checkPassword(string passwordGet)
        {
            Password password = new Password();
            password.PasswordItself=passwordGet;
            var result = Zxcvbn.Core.EvaluatePassword(password.PasswordItself);
            password.Level = result.Score;
            return password;
        }
}
}
