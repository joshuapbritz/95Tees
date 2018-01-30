using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using evan.ninetyfivetees.web.Models;
using Microsoft.EntityFrameworkCore;

namespace evan.ninetyfivetees.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ninetyfiveteesContext _context;

        public HomeController(ninetyfiveteesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Shirts> shirts = await _context.Shirts.Include(s => s.Color).Include(s => s.Design).Include(s => s.Size).Take(6).ToListAsync();
            return View(shirts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
