using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chate.Business_Layer;
using Microsoft.AspNetCore.Mvc;

namespace Chate.Controllers
{
    public class A_RController : Controller
    {
        ManagerUser managerUser = new ManagerUser();

        //Возвращает фопму авторизации
        public IActionResult Avtorization()
        {
            ViewData["page"]     = "Авторизация";
            ViewData["isHidden"] = true;
            ViewData["hidden"]   = true;
            return View("Avtorization");
        }

        //Возвращает фопму регистрации
        public IActionResult Registration()
        {
            ViewData["page"]     = "Регистрация";
            ViewData["isHidden"] = true;
            ViewData["hidden"]   = true;
            return View("Registration");
        }

        //Метод\Контроллер аторизации
        [HttpPost]
        public IActionResult Avtorization(string login, string password)
        {
            IActionResult actionResult = null;

            //Проверка бдет ли авторизован 
            //true  - редирект на контролер Chate
            //false - возврат на форму авторизации
            if (managerUser.Avtorization(login, password))
            {
                actionResult = RedirectToAction("Chate", "FromeChate", new { login });
            }
            else
            {
                ViewData["page"]     = "Авторизация";
                ViewData["isHidden"] = false;
                ViewData["hidden"]   = true;
                actionResult         = View("Avtorization");
            }
            return actionResult;

        }

        //Метод\Контроллер регистрации
        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            IActionResult actionResult = null;

            //Проверка бдет ли зарегистрирован
            //true  - редирект на контролер Chate
            //false - возврат на форму регистрации
            if (managerUser.Registration(login, password))
            {
                actionResult = RedirectToAction("Chate", "FromeChate", new { login });
            }
            else
            {
                ViewData["page"]     = "Регистрация";
                ViewData["hidden"]   = true;
                ViewData["isHidden"] = false;
                actionResult         = View("Registration");
            }
            return actionResult;
            
        }
    }
}