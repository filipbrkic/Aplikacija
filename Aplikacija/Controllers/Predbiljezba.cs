using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Controllers
{
    public class Predbiljezba : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
