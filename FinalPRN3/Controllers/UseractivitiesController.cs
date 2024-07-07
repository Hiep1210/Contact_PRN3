using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalPRN3.Models;

namespace FinalPRN3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseractivitiesController : ControllerBase
    {
        private readonly lovetientdContext _context;

        public UseractivitiesController(lovetientdContext context)
        {
            _context = context;
        }

        // GET: api/Useractivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Useractivity>>> GetUseractivities()
        {
          if (_context.Useractivities == null)
          {
              return NotFound();
          }
            return await _context.Useractivities.ToListAsync();
        }

        // GET: api/Useractivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Useractivity>> GetUseractivity(int id)
        {
          if (_context.Useractivities == null)
          {
              return NotFound();
          }
            var useractivity = await _context.Useractivities.FindAsync(id);

            if (useractivity == null)
            {
                return NotFound();
            }

            return useractivity;
        }

        // PUT: api/Useractivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUseractivity(int id, Useractivity useractivity)
        {
            if (id != useractivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(useractivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UseractivityExists(id))
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

        // POST: api/Useractivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Useractivity>> PostUseractivity(Useractivity useractivity)
        {
          if (_context.Useractivities == null)
          {
              return Problem("Entity set 'lovetientdContext.Useractivities'  is null.");
          }
            _context.Useractivities.Add(useractivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUseractivity", new { id = useractivity.Id }, useractivity);
        }

        // DELETE: api/Useractivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUseractivity(int id)
        {
            if (_context.Useractivities == null)
            {
                return NotFound();
            }
            var useractivity = await _context.Useractivities.FindAsync(id);
            if (useractivity == null)
            {
                return NotFound();
            }

            _context.Useractivities.Remove(useractivity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UseractivityExists(int id)
        {
            return (_context.Useractivities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
