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

    //public class EOViewComponent : ViewComponent
    //{
    //    private DbContextOptions<ApplicationDbContext> db = new DbContextOptions<ApplicationDbContext>();
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        ApplicationDbContext context = new ApplicationDbContext(db);
    //        IEnumerable<ExpertOpinions> mc = await context.ExpertOpinions.Where(y => y.StructuralSelfInteractionID == id).Include(e => e.Expert).Include(e => e.SSI).ToListAsync();
    //        return View("Index", mc);
    //    }
    //}
    public class EOController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EOController(ApplicationDbContext context)
        {
            _context = context;
        }

            // GET: EO
        [HttpGet]
        public async Task<IActionResult> Data(int id)
        {
            var applicationDbContext = _context.ExpertOpinions.Where(y=>y.StructuralSelfInteractionID==id).Include(e => e.Expert).Include(e => e.SSI);
            ViewData["SSIID"] = id;
            return PartialView("Index", await applicationDbContext.ToListAsync());
        }

        // GET: EO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExpertOpinions == null)
            {
                return NotFound();
            }

            var expertOpinions = await _context.ExpertOpinions
                .Include(e => e.Expert)
                .Include(e => e.SSI)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (expertOpinions == null)
            {
                return NotFound();
            }

            return View(expertOpinions);
        }

        // GET: EO/Create
        public IActionResult Create(int id)
        {
            List<String> interaction = new List<String>() { "V", "A", "X", "O" };
            var ssi = _context.StructuralSelfInteractions.Find(id);
            var featureA = _context.Features.Find(ssi.FeatureAID);
            var featureB = _context.Features.Find(ssi.FeatureBID);
            ViewData["f1"] = featureA.Code;
            ViewData["f2"] = featureB.Code;
            var project = _context.ProjectIdentitiy.Find(featureA.ProjectID);
            ViewData["ExpertID"] = new SelectList(_context.Experts.Where(y=>y.ProjectID==project.ID), "ID", "Name");
            ViewData["StructuralSelfInteractionID"] = id;
            ViewData["InteractionType"] = new SelectList(interaction);
            return View();
        }

        // POST: EO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ExpertID,StructuralSelfInteractionID,Opinion,InteractionType")] ExpertOpinions expertOpinions)
        {
            expertOpinions.ID = 0;
            var ssi = _context.StructuralSelfInteractions.Find(expertOpinions.StructuralSelfInteractionID);
            var featureA = _context.Features.Find(ssi.FeatureAID);
            var featureB = _context.Features.Find(ssi.FeatureBID);
                _context.ExpertOpinions.Add(expertOpinions);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateInteraction","Features", new { id=featureA.ID, id2=featureB.ID });
        }

        // GET: EO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExpertOpinions == null)
            {
                return NotFound();
            }

            var expertOpinions = await _context.ExpertOpinions.FindAsync(id);
            if (expertOpinions == null)
            {
                return NotFound();
            }
            ViewData["ExpertID"] = new SelectList(_context.Experts, "ID", "ID", expertOpinions.ExpertID);
            ViewData["StructuralSelfInteractionID"] = new SelectList(_context.StructuralSelfInteractions, "ID", "ID", expertOpinions.StructuralSelfInteractionID);
            return View(expertOpinions);
        }

        // POST: EO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ExpertID,StructuralSelfInteractionID,InteractionType")] ExpertOpinions expertOpinions)
        {
            if (id != expertOpinions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expertOpinions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpertOpinionsExists(expertOpinions.ID))
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
            ViewData["ExpertID"] = new SelectList(_context.Experts, "ID", "ID", expertOpinions.ExpertID);
            ViewData["StructuralSelfInteractionID"] = new SelectList(_context.StructuralSelfInteractions, "ID", "ID", expertOpinions.StructuralSelfInteractionID);
            return View(expertOpinions);
        }

        // GET: EO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExpertOpinions == null)
            {
                return NotFound();
            }

            var expertOpinions = await _context.ExpertOpinions
                .Include(e => e.Expert)
                .Include(e => e.SSI)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (expertOpinions == null)
            {
                return NotFound();
            }

            return View(expertOpinions);
        }

        // POST: EO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpertOpinions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExpertOpinions'  is null.");
            }
            var expertOpinions = await _context.ExpertOpinions.FindAsync(id);
            if (expertOpinions != null)
            {
                _context.ExpertOpinions.Remove(expertOpinions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpertOpinionsExists(int id)
        {
          return (_context.ExpertOpinions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
