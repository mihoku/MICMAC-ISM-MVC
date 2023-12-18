using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MICMAC_ISM_MVC.Data;
using MICMAC_ISM_MVC.Models;

namespace MICMAC_ISM_MVC.Controllers
{
    public class ExpertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Experts
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.Experts.Include(f => f.ProjectIdentity)
                .Where(m => m.ProjectID == id);
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Experts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Experts == null)
            {
                return NotFound();
            }

            var experts = await _context.Experts
                .Include(e => e.ProjectIdentity)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experts == null)
            {
                return NotFound();
            }

            return View(experts);
        }

        // GET: Experts/Create
        public IActionResult Create(int id)
        {
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            return View();
        }

        // POST: Experts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Organization,ProjectID")] Experts experts)
        {
                _context.Add(experts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Experts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Experts == null)
            {
                return NotFound();
            }

            var experts = await _context.Experts.FindAsync(id);
            if (experts == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = experts.ProjectID;
            return View(experts);
        }

        // POST: Experts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Organization,ProjectID")] Experts experts)
        {
            if (id != experts.ID)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(experts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpertsExists(experts.ID))
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

        // GET: Experts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Experts == null)
            {
                return NotFound();
            }

            var experts = await _context.Experts
                .Include(e => e.ProjectIdentity)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experts == null)
            {
                return NotFound();
            }

            return View(experts);
        }

        // POST: Experts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Experts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Experts'  is null.");
            }
            var experts = await _context.Experts.FindAsync(id);
            if (experts != null)
            {
                _context.Experts.Remove(experts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpertsExists(int id)
        {
          return (_context.Experts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
