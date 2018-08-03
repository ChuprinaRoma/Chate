using Chate.Business_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.DAO
{
    public class SqlEntityFramworke
    {
        private static Context context = new Context();

        //Проверка на существовани логина или логина и пароля
        public static bool ExistsDataUser(string login, string password = null)
        {
            bool isDataUser = false;

            try
            {
                //true - проверка существвание пароля и логина в бд (Для аторизации)
                //false - проверка существования логина в бд (Для регистрации)
                if (password != null)
                {
                    isDataUser = context.User.ToList().Exists(u => u.Login == login && u.Passrwod == password);
                }
                else
                {
                    isDataUser = context.User.ToList().Exists(u => u.Login == login);
                }
            }
            catch(Exception)
            {
                isDataUser = false;
            }

            return isDataUser;
        }

        //Добавление пользователя в бд
        public static void AddDbUser(string loginn, string password)
        {
            context.User.Add(new User(loginn, password));
            context.SaveChanges();
        }

        //Добавление в сообщение в бд
        public static void AddChate(string login, string mesage)
        {
            context.Chate.Add(new Model.Chate(login, mesage));
            context.SaveChanges();
        }

        //Вытягивание сообщение из бд
        public static List<Model.Chate> GetMesage()
        {
            return context.Chate.ToList();
        }
    }
}
