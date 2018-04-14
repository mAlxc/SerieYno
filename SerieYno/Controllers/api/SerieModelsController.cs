using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieYno.Data;
using SerieYnoModels.Models;

namespace SerieYno.Controllers.api
{
    [Produces("application/json")]
    [Route("api/SerieModels")]
    public class SerieModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SerieModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SerieModels
        [HttpGet]
        public IEnumerable<SerieModel> GetSerie()
        {
            return _context.Serie;
        }

        // GET: api/SerieModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerieModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serieModel = await _context.Serie.SingleOrDefaultAsync(m => m.ID == id);

            if (serieModel == null)
            {
                return NotFound();
            }

            return Ok(serieModel);
        }

        // PUT: api/SerieModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerieModel([FromRoute] Guid id, [FromBody] SerieModel serieModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serieModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(serieModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SerieModels
        [HttpPost]
        public async Task<IActionResult> PostSerieModel([FromBody] SerieModel serieModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Serie.Add(serieModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerieModel", new { id = serieModel.ID }, serieModel);
        }

        // DELETE: api/SerieModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerieModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serieModel = await _context.Serie.SingleOrDefaultAsync(m => m.ID == id);
            if (serieModel == null)
            {
                return NotFound();
            }

            _context.Serie.Remove(serieModel);
            await _context.SaveChangesAsync();

            return Ok(serieModel);
        }

        private bool SerieModelExists(Guid id)
        {
            return _context.Serie.Any(e => e.ID == id);
        }
    }
}