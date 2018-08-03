using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chate.Business_Layer;
using Chate.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Chate.Controllers
{
    public class FromeChateController : Controller
    {
        //Возвращает фопму авторизации
        public IActionResult Chate(string login)
        {
            //Проверка на существооние в базе такого пользователя 
            //true  - возврат страницу чата
            //false - редирект на форму авторизации
            if (SqlEntityFramworke.ExistsDataUser(login))
            {
                ViewData["page"] = $"Nick: {login}";
                ViewData["login"] = login;
                ViewData["hidden"] = false;
                ViewBag.Chat = SqlEntityFramworke.GetMesage();
                ViewBag.user = ManagerUser.users;
                return View("Chate");
            }
            else
            {
                return RedirectToAction("Avtorization", "A_R");
            }
        }
    }
}