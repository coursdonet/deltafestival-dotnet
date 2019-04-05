using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationsController : ControllerBase
    {
        private readonly EfContext _context;

        public LocalizationsController(EfContext context)
        {
            _context = context;
        }

        // GET: api/Localizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localization>>> GetLocalizations()
        {
            return await _context.Localizations.ToListAsync();
        }

        // GET: api/Localizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localization>> GetLocalization(Guid id)
        {
            var localization = await _context.Localizations.FindAsync(id);

            if (localization == null)
            {
                return NotFound();
            }

            return localization;
        }

        // PUT: api/Localizations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalization(Guid id, Localization localization)
        {
            if (id != localization.Id)
            {
                return BadRequest();
            }

            _context.Entry(localization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalizationExists(id))
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

        // POST: api/Localizations
        [HttpPost]
        public async Task<ActionResult<Localization>> PostLocalization(Localization localization)
        {
            _context.Localizations.Add(localization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalization", new { id = localization.Id }, localization);
        }

        // DELETE: api/Localizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Localization>> DeleteLocalization(Guid id)
        {
            var localization = await _context.Localizations.FindAsync(id);
            if (localization == null)
            {
                return NotFound();
            }

            _context.Localizations.Remove(localization);
            await _context.SaveChangesAsync();

            return localization;
        }

        private bool LocalizationExists(Guid id)
        {
            return _context.Localizations.Any(e => e.Id == id);
        }
    }
}
