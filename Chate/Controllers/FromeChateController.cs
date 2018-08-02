using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chate.Controllers
{
    public class FromeChateController : Controller
    {
        public IActionResult Chate(string login)
        {
            ViewData["page"] = $"Nick: {login}";
            return View("Chate");
        }
    }
}