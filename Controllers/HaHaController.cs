using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeMoMVCNetCore.Data;
using DeMoMVCNetCore.Models;

namespace DeMoMVCNetCore.Controllers
{
    public class HaHaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public HaHaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: HaHa
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.HiHi.Include(h => h.Category);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: HaHa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiHi = await _context.HiHi
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.HiHiId == id);
            if (hiHi == null)
            {
                return NotFound();
            }

            return View(hiHi);
        }

        // GET: HaHa/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: HaHa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HiHiId,HiHIname,CategoryID")] HiHi hiHi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hiHi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", hiHi.CategoryID);
            return View(hiHi);
        }

        // GET: HaHa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiHi = await _context.HiHi.FindAsync(id);
            if (hiHi == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", hiHi.CategoryID);
            return View(hiHi);
        }

        // POST: HaHa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HiHiId,HiHIname,CategoryID")] HiHi hiHi)
        {
            if (id != hiHi.HiHiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hiHi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HiHiExists(hiHi.HiHiId))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", hiHi.CategoryID);
            return View(hiHi);
        }

        // GET: HaHa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiHi = await _context.HiHi
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.HiHiId == id);
            if (hiHi == null)
            {
                return NotFound();
            }

            return View(hiHi);
        }

        // POST: HaHa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hiHi = await _context.HiHi.FindAsync(id);
            _context.HiHi.Remove(hiHi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HiHiExists(int id)
        {
            return _context.HiHi.Any(e => e.HiHiId == id);
        }
    }
}
