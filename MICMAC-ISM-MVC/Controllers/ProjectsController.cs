using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MICMAC_ISM_MVC.Data;
using MICMAC_ISM_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace MICMAC_ISM_MVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicationDbContext db;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
              return _context.ProjectIdentitiy != null ? 
                          View(await _context.ProjectIdentitiy.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProjectIdentitiy'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectIdentitiy == null)
            {
                return NotFound();
            }

            var projectIdentitiy = await _context.ProjectIdentitiy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectIdentitiy == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = projectIdentitiy.ID;
            return View(projectIdentitiy);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Organization")] ProjectIdentitiy projectIdentitiy)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(projectIdentitiy);
                //db.SaveChanges();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(projectIdentitiy);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectIdentitiy == null)
            {
                return NotFound();
            }

            var projectIdentitiy = await _context.ProjectIdentitiy.FindAsync(id);
            if (projectIdentitiy == null)
            {
                return NotFound();
            }
            return View(projectIdentitiy);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Organization")] ProjectIdentitiy projectIdentitiy)
        {
            if (id != projectIdentitiy.ID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(projectIdentitiy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectIdentitiyExists(projectIdentitiy.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //return View(projectIdentitiy);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectIdentitiy == null)
            {
                return NotFound();
            }

            var projectIdentitiy = await _context.ProjectIdentitiy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectIdentitiy == null)
            {
                return NotFound();
            }

            return View(projectIdentitiy);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectIdentitiy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProjectIdentitiy'  is null.");
            }
            var projectIdentitiy = await _context.ProjectIdentitiy.FindAsync(id);
            if (projectIdentitiy != null)
            {
                _context.ProjectIdentitiy.Remove(projectIdentitiy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectIdentitiyExists(int id)
        {
          return (_context.ProjectIdentitiy?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
