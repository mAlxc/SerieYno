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
    [Route("api/SaisonModels")]
    public class SaisonModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaisonModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SaisonModels
        [HttpGet]
        public IEnumerable<SaisonModel> GetSaisonModel()
        {
            return _context.SaisonModel;
        }

        // GET: api/SaisonModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaisonModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var saisonModel = await _context.SaisonModel.SingleOrDefaultAsync(m => m.ID == id);

            if (saisonModel == null)
            {
                return NotFound();
            }

            return Ok(saisonModel);
        }

        // PUT: api/SaisonModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaisonModel([FromRoute] Guid id, [FromBody] SaisonModel saisonModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saisonModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(saisonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaisonModelExists(id))
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

        // POST: api/SaisonModels
        [HttpPost]
        public async Task<IActionResult> PostSaisonModel([FromBody] SaisonModel saisonModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SaisonModel.Add(saisonModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaisonModel", new { id = saisonModel.ID }, saisonModel);
        }

        // DELETE: api/SaisonModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaisonModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var saisonModel = await _context.SaisonModel.SingleOrDefaultAsync(m => m.ID == id);
            if (saisonModel == null)
            {
                return NotFound();
            }

            _context.SaisonModel.Remove(saisonModel);
            await _context.SaveChangesAsync();

            return Ok(saisonModel);
        }

        private bool SaisonModelExists(Guid id)
        {
            return _context.SaisonModel.Any(e => e.ID == id);
        }
    }
}