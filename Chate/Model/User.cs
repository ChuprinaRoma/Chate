using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.Business_Layer.Model
{
    //Общая моделб клиента, для онлайн списка и БД
    public class User
    {
        public int id          { get; set; }
        public string Login    { get; set; }
        public string Passrwod { get; set; }

        public User(string login)
        {
            Login = login;
        }

        //Конструктор для добавления в БД
        public User(string login, string password)
        {
            Login    = login;
            Passrwod = password;
        }

        //Конструктор для БД
        public User() { }

    }
}
