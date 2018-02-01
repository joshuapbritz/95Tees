using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using evan.ninetyfivetees.web.Models;
using Microsoft.AspNetCore.Authorization;

namespace evan.ninetyfivetees.web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class adminController : Controller
    {
        private readonly ninetyfiveteesContext _context;

        public adminController(ninetyfiveteesContext context)
        {
            _context = context;
        }

        // GET: admin
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Shirts()
        {
            var ninetyfiveteesContext = _context.Shirts
            .Include(s => s.Color)
            .Include(s => s.Design)
            .Include(s => s.Gender)
            .Include(s => s.IdNavigation)
            .Include(s => s.Season)
            .Include(s => s.ShirtSizes)
            .Include("ShirtSizes.Size");
            return View(await ninetyfiveteesContext.ToListAsync());
        }

        // GET: admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirts = await _context.Shirts
                .Include(s => s.Color)
                .Include(s => s.Design)
                .Include(s => s.Gender)
                .Include(s => s.IdNavigation)
                .Include(s => s.Season)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shirts == null)
            {
                return NotFound();
            }

            return View(shirts);
        }

        // GET: admin/Create
        [HttpGet]
        [ActionName("newshirt")]
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Name");
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Description");
            ViewData["Id"] = new SelectList(_context.Shirts, "Id", "Id");
            ViewData["SeasonId"] = new SelectList(_context.YearSeasons, "Id", "Name");
            return View("Create");
        }

        // POST: admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shirts shirts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shirts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", shirts.ColorId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id", shirts.DesignId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", shirts.GenderId);
            ViewData["Id"] = new SelectList(_context.Shirts, "Id", "Id", shirts.Id);
            ViewData["SeasonId"] = new SelectList(_context.YearSeasons, "Id", "Id", shirts.SeasonId);
            return View(shirts);
        }

        // GET: admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirts = await _context.Shirts.SingleOrDefaultAsync(m => m.Id == id);
            if (shirts == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", shirts.ColorId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id", shirts.DesignId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", shirts.GenderId);
            ViewData["Id"] = new SelectList(_context.Shirts, "Id", "Id", shirts.Id);
            ViewData["SeasonId"] = new SelectList(_context.YearSeasons, "Id", "Id", shirts.SeasonId);
            return View(shirts);
        }

        // POST: admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColorId,Description,DesignId,GenderId,Image,Instock,Price,SeasonId,Title")] Shirts shirts)
        {
            if (id != shirts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shirts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShirtsExists(shirts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", shirts.ColorId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id", shirts.DesignId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", shirts.GenderId);
            ViewData["Id"] = new SelectList(_context.Shirts, "Id", "Id", shirts.Id);
            ViewData["SeasonId"] = new SelectList(_context.YearSeasons, "Id", "Id", shirts.SeasonId);
            return View(shirts);
        }

        // GET: admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirts = await _context.Shirts
                .Include(s => s.Color)
                .Include(s => s.Design)
                .Include(s => s.Gender)
                .Include(s => s.IdNavigation)
                .Include(s => s.Season)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shirts == null)
            {
                return NotFound();
            }

            return View(shirts);
        }

        // POST: admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shirts = await _context.Shirts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Shirts.Remove(shirts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShirtsExists(int id)
        {
            return _context.Shirts.Any(e => e.Id == id);
        }
    }
}
