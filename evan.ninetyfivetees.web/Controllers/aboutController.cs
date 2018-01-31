using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace evan.ninetyfivetees.web.Controllers
{
    public class aboutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["activePage"] = "about";

            return View();
        }
    }
}