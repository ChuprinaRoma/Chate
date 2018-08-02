using Chate.Business_Layer.Model;
using Chate.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.Business_Layer
{
    public class ManagerUser
    {
        List<User> users =  new List<User>();
        SqlEntityFramworke sqlEntityFramworke = new SqlEntityFramworke();

        public bool Registration(string login, string password)
        {
            bool isRegistration = false;
            if (!sqlEntityFramworke.ExistsDataUser(login))
            {
                users.Add(new User(login, password));
                sqlEntityFramworke.AddDbUser(login, password);
                isRegistration = true;
            }
            return isRegistration;
        }

        public bool Avtorization(string login, string password)
        {
            bool isRegistration = false;
            if (sqlEntityFramworke.ExistsDataUser(login, password))
            {
                users.Add(new User(login, password));
                isRegistration = true;
            }
            return isRegistration;
        }
    }
}
