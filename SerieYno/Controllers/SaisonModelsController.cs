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
    public class SaisonModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaisonModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaisonModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SaisonModel.Include(s => s.Serie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SaisonModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saisonModel = await _context.SaisonModel
                .Include(s => s.Serie)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saisonModel == null)
            {
                return NotFound();
            }

            return View(saisonModel);
        }

        // GET: SaisonModels/Create
        public IActionResult Create()
        {
            ViewData["SerieId"] = new SelectList(_context.Serie, "ID", "Name_serie");
            return View();
        }

        // POST: SaisonModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerieId,Num_saison,ID,UpdatedAt,DeletedAt,Deleted")] SaisonModel saisonModel)
        {
            if (ModelState.IsValid)
            {
                saisonModel.ID = Guid.NewGuid();
                _context.Add(saisonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SerieId"] = new SelectList(_context.Serie, "ID", "Name_serie", saisonModel.SerieId);
            return View(saisonModel);
        }

        // GET: SaisonModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saisonModel = await _context.SaisonModel.SingleOrDefaultAsync(m => m.ID == id);
            if (saisonModel == null)
            {
                return NotFound();
            }
            ViewData["SerieId"] = new SelectList(_context.Serie, "ID", "Name_serie", saisonModel.SerieId);
            return View(saisonModel);
        }

        // POST: SaisonModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SerieId,Num_saison,ID,UpdatedAt,DeletedAt,Deleted")] SaisonModel saisonModel)
        {
            if (id != saisonModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saisonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaisonModelExists(saisonModel.ID))
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
            ViewData["SerieId"] = new SelectList(_context.Serie, "ID", "Name_serie", saisonModel.SerieId);
            return View(saisonModel);
        }

        // GET: SaisonModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saisonModel = await _context.SaisonModel
                .Include(s => s.Serie)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saisonModel == null)
            {
                return NotFound();
            }

            return View(saisonModel);
        }

        // POST: SaisonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var saisonModel = await _context.SaisonModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.SaisonModel.Remove(saisonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaisonModelExists(Guid id)
        {
            return _context.SaisonModel.Any(e => e.ID == id);
        }
    }
}
