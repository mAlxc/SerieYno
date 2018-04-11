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
    [Route("api/UserApibis")]
    public class UserApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserApi
        [HttpGet]
        public IEnumerable<ApplicationUser> GetApplicationUser()
        {
            return _context.ApplicationUser;
        }

        // GET: api/UserApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        // PUT: api/UserApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUser([FromRoute] string id, [FromBody] ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
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

        // POST: api/UserApi
        [HttpPost]
        public async Task<IActionResult> PostApplicationUser([FromBody] ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ApplicationUser.Add(applicationUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/UserApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();

            return Ok(applicationUser);
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}