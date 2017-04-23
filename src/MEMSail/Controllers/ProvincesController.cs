using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEMSail.Models;
using System.Text.RegularExpressions;

namespace MEMSail.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly SailContext _context;

        public ProvincesController(SailContext context)
        {
            _context = context;    
        }

        // GET: Provinces
        public async Task<IActionResult> Index()
        {
            var sailContext = _context.Province.Include(p => p.CountryCodeNavigation);
            return View(await sailContext.ToListAsync());
        }

        // GET: Provinces/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Province.SingleOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // GET: Provinces/Create
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.Country, "CountryCode", "CountryCode");
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceCode,Capital,CountryCode,Name,TaxCode,TaxRate")] Province province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CountryCode"] = new SelectList(_context.Country, "CountryCode", "CountryCode", province.CountryCode);
            return View(province);
        }

        // GET: Provinces/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var province = await _context.Province.SingleOrDefaultAsync(m => m.ProvinceCode == id);
                if (province == null)
                {
                    return NotFound();
                }
                ViewData["CountryCode"] = new SelectList(_context.Country, "CountryCode", "CountryCode", province.CountryCode);
                return View(province);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Cannot navigate to the edit province page" + ex.GetBaseException().Message);
                return RedirectToAction(actionName: "Index", controllerName: "Provinces");
            }
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProvinceCode,Capital,CountryCode,Name,TaxCode,TaxRate")] Province province)
        {
            try
            {
                if (id != province.ProvinceCode)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        province.ProvinceCode = province.ProvinceCode;
                        _context.Update(province);
                        await _context.SaveChangesAsync();
                        TempData["Message"] = "Province details added successfully";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProvinceExists(province.ProvinceCode))
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
                ViewData["CountryCode"] = new SelectList(_context.Country, "CountryCode", "CountryCode", province.CountryCode);
                return View(province);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Cannot edit province" + ex.GetBaseException().Message);
                return RedirectToAction(actionName: "Edit", controllerName: "Provinces");
            }
        }

        // GET: Provinces/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Province.SingleOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var province = await _context.Province.SingleOrDefaultAsync(m => m.ProvinceCode == id);
            _context.Province.Remove(province);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public JsonResult ProvinceCodeValidation(String provinceCode)
        {
            Regex pattern = new Regex(@"^[A-Za-z][A-Za-z]$", RegexOptions.IgnoreCase);
            if (pattern.IsMatch(provinceCode))
            {
                try
                {
                    var provinces = from result in _context.Province where result.ProvinceCode == provinceCode select result;
                    if (!provinces.Any())
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json("Province already exists");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"error  {ex.GetBaseException().Message}");
                }
            }
            return Json("Too long/short");
        }
        private bool ProvinceExists(string id)
        {
            return _context.Province.Any(e => e.ProvinceCode == id);
        }
    }
}
