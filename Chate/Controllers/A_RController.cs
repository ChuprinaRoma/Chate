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

        public IActionResult Avtorization()
        {
            ViewData["page"] = "Авторизация";
            ViewData["isHidden"] = true;
            return View("Avtorization");
        }
        
        public IActionResult Registration()
        {
            ViewData["page"] = "Регистрация";
            ViewData["isHidden"] = true;
            return View("Registration");
        }

        [HttpPost]
        public IActionResult Avtorization(string login, string password)
        {
            IActionResult actionResult = null;
            if (managerUser.Avtorization(login, password))
            {
                actionResult = RedirectToAction("Chate", "FromeChate", new { login });
            }
            else
            {
                ViewData["page"] = "Авторизация";
                ViewData["isHidden"] = false;
                actionResult = View("Avtorization");
            }
            return actionResult;

        }

        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            IActionResult actionResult = null;
            if (managerUser.Registration(login, password))
            {
                actionResult = RedirectToAction("Chate", "FromeChate", new { login });
            }
            else
            {
                ViewData["page"] = "Регистрация";
                ViewData["isHidden"] = false;
                actionResult = View("Registration");
            }
            return actionResult;
            
        }
    }
}