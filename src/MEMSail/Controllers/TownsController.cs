using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEMSail.Models;

namespace MEMSail.Controllers
{
    public class TownsController : Controller
    {
        private readonly SailContext _context;

        public TownsController(SailContext context)
        {
            _context = context;    
        }

        // GET: Towns
        public async Task<IActionResult> Index()
        {
            var sailContext = _context.Town.Include(t => t.ProvinceCodeNavigation);
            return View(await sailContext.ToListAsync());
        }

        // GET: Towns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var town = await _context.Town.SingleOrDefaultAsync(m => m.TownName == id);
            if (town == null)
            {
                return NotFound();
            }

            return View(town);
        }

        // GET: Towns/Create
        public IActionResult Create()
        {
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode");
            return View();
        }

        // POST: Towns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TownName,ProvinceCode")] Town town)
        {
            if (ModelState.IsValid)
            {
                _context.Add(town);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", town.ProvinceCode);
            return View(town);
        }

        // GET: Towns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var town = await _context.Town.SingleOrDefaultAsync(m => m.TownName == id);
            if (town == null)
            {
                return NotFound();
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", town.ProvinceCode);
            return View(town);
        }

        // POST: Towns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TownName,ProvinceCode")] Town town)
        {
            if (id != town.TownName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(town);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TownExists(town.TownName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", town.ProvinceCode);
            return View(town);
        }

        // GET: Towns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var town = await _context.Town.SingleOrDefaultAsync(m => m.TownName == id);
            if (town == null)
            {
                return NotFound();
            }

            return View(town);
        }

        // POST: Towns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var town = await _context.Town.SingleOrDefaultAsync(m => m.TownName == id);
            _context.Town.Remove(town);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TownExists(string id)
        {
            return _context.Town.Any(e => e.TownName == id);
        }
    }
}
