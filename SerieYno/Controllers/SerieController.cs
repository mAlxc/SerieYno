using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SerieYno.Data;
using Microsoft.EntityFrameworkCore;

namespace SerieYno.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SerieController : BaseDController
    {
        public SerieController(ApplicationDbContext context) : base(context)
        {
        }


        [TempData]
        public string ErrorMessage { get; set; }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Serie.ToListAsync());
        }

        // POST: Backoffice/Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name_serie,Description,OddTeam1,OddTeam2,OddDraw")] SerieYnoModels.Models.SerieModel serie)
        {
            if (ModelState.IsValid)
            {
                serie.ID = Guid.NewGuid();
                serie.UpdatedAt = DateTime.Now;
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    }
}