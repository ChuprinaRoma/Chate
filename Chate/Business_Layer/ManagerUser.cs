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
        public static List<User> users =  new List<User>();

        //Метот для регистрации
        public bool Registration(string login, string password)
        {
            bool isRegistration = false;
            if(login == null)
                return false;

            //true - регистрируем и добаляем в базу
            if (!SqlEntityFramworke.ExistsDataUser(login))
            {
                SqlEntityFramworke.AddDbUser(login, password);
                isRegistration = true;
            }
            return isRegistration;
        }

        //Метот для авторизации
        public bool Avtorization(string login, string password)
        {
            bool isRegistration = false;
            if(password == null || login == null)
                return false;

            //true - аторизируем
            if (SqlEntityFramworke.ExistsDataUser(login, password))
            {
                isRegistration = true;
            }
            return isRegistration;
        }
    }
}
