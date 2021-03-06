﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerieYno.Data;
using SerieYnoModels.Models;
using SerieYno.ViewsModels;
using SerieYno.ViewsModels.SerieViewModels;

namespace SerieYno.Controllers
{
    public class SerieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SerieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Serie
        public async Task<IActionResult> Index(Guid? id, Guid? saisonId)
        {
            var viewModel = new FullViewModel();
            viewModel.SerieModel = _context.SerieModel
                .OrderBy(i => i.Name_serie);

            if (id != null)
            {
                ViewBag.SerieId = id.Value;
                viewModel.SaisonModel = viewModel.SerieModel.Where(
                    i => i.ID == id.Value).Single().Saisons;
            }

            if (saisonId != null)
            {
                ViewBag.SaisonId = saisonId.Value;
                viewModel.EpisodeModel = viewModel.SaisonModel.Where(
                    x => x.ID == saisonId.Value).Single().Episodes;
            }

            return View(viewModel);
        }

        // GET: Serie/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serieModel = await _context.Serie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (serieModel == null)
            {
                return NotFound();
            }

            return View(serieModel);
        }

        // GET: Serie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Serie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name_serie,Description,Photo_serie,Num_max_ep,Num_max_saison,ID,UpdatedAt,DeletedAt,Deleted")] SerieModel serieModel)
        {
            if (ModelState.IsValid)
            {
                serieModel.ID = Guid.NewGuid();
                _context.Add(serieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serieModel);
        }

        // GET: Serie/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serieModel = await _context.Serie.SingleOrDefaultAsync(m => m.ID == id);
            if (serieModel == null)
            {
                return NotFound();
            }
            return View(serieModel);
        }

        // POST: Serie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name_serie,Description,Photo_serie,Num_max_ep,Num_max_saison,ID,UpdatedAt,DeletedAt,Deleted")] SerieModel serieModel)
        {
            if (id != serieModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerieModelExists(serieModel.ID))
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
            return View(serieModel);
        }

        // GET: Serie/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serieModel = await _context.Serie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (serieModel == null)
            {
                return NotFound();
            }

            return View(serieModel);
        }

        // POST: Serie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serieModel = await _context.Serie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Serie.Remove(serieModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerieModelExists(Guid id)
        {
            return _context.Serie.Any(e => e.ID == id);
        }
    }
}
