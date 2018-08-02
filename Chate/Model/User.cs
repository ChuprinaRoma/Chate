using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.Business_Layer.Model
{
    public class User
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Passrwod { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Passrwod = password;
        }

        public User() { }

    }
}
