using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerieYno.Data;
using SerieYnoModels.Models;

namespace SerieYno.Controllers
{
    public class EpisodeModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EpisodeModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EpisodeModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EpisodeModel.Include(e => e.Saison);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EpisodeModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodeModel = await _context.EpisodeModel
                .Include(e => e.Saison)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (episodeModel == null)
            {
                return NotFound();
            }

            return View(episodeModel);
        }

        // GET: EpisodeModels/Create
        public IActionResult Create()
        {
            ViewData["SaisonId"] = new SelectList(_context.Serie, "ID", "Name_serie");
            return View();
        }

        // POST: EpisodeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num_ep,Name_ep,Description,SaisonId,ID,UpdatedAt,DeletedAt,Deleted")] EpisodeModel episodeModel)
        {
            if (ModelState.IsValid)
            {
                episodeModel.ID = Guid.NewGuid();
                _context.Add(episodeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SaisonId"] = new SelectList(_context.Serie, "ID", "Description", episodeModel.SaisonId);
            return View(episodeModel);
        }

        // GET: EpisodeModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodeModel = await _context.EpisodeModel.SingleOrDefaultAsync(m => m.ID == id);
            if (episodeModel == null)
            {
                return NotFound();
            }
            ViewData["SaisonId"] = new SelectList(_context.Serie, "ID", "Description", episodeModel.SaisonId);
            return View(episodeModel);
        }

        // POST: EpisodeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Num_ep,Name_ep,Description,SaisonId,ID,UpdatedAt,DeletedAt,Deleted")] EpisodeModel episodeModel)
        {
            if (id != episodeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episodeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodeModelExists(episodeModel.ID))
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
            ViewData["SaisonId"] = new SelectList(_context.Serie, "ID", "Description", episodeModel.SaisonId);
            return View(episodeModel);
        }

        // GET: EpisodeModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodeModel = await _context.EpisodeModel
                .Include(e => e.Saison)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (episodeModel == null)
            {
                return NotFound();
            }

            return View(episodeModel);
        }

        // POST: EpisodeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var episodeModel = await _context.EpisodeModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.EpisodeModel.Remove(episodeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodeModelExists(Guid id)
        {
            return _context.EpisodeModel.Any(e => e.ID == id);
        }
    }
}
