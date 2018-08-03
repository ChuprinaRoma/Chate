using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.DAO.Model
{
    //Модель в БД чата
    public class Chate
    {
        public int id        { get; set; }
        public string Login  { get; set; }
        public string Mesage { get; set; }

        //Конструктор для БД
        public Chate() { }

        //Конструктор для добавление в базу
        public Chate(string login, string mesage)
        {
            Login  = login;
            Mesage = mesage;
        }
    }
}
