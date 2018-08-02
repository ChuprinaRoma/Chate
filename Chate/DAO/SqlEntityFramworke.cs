using Chate.Business_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.DAO
{
    public class SqlEntityFramworke
    {
        private Context context = new Context();

        public bool ExistsDataUser(string login, string password = null)
        {
            bool isDataUser = false;
            if (context.User.Count() != 0)
            {
                if (password != null)
                {
                    isDataUser = context.User.ToList().Exists(u => u.Login == login && u.Passrwod == password);
                }
                {
                    isDataUser = context.User.ToList().Exists(u => u.Login == login);
                }
            }
            return isDataUser;
        }

        public void AddDbUser(string loginn, string password)
        {
            context.User.Add(new User(loginn, password));
            context.SaveChanges();
        }
    }
}
