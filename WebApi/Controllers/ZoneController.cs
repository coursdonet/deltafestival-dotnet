using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using Database;
using Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly MapContext _context;

        public ZoneController(MapContext context) => _context = context;


        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZones()
        {


            return await _context.Zones.ToListAsync();


            
        }

        // GET: api/Zones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zone>> GetZones(int id)
        {
            var zone = await _context.Zones.FindAsync(id);

            if (zone == null)
            {
                return NotFound();
            }

            return zone;
        }

        // POST: api/Zones
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone)
        {
            _context.Zones.Add(zone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZones", new { id = zone.Id }, zone);
        }

        // DELETE: api/Zones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zone>> DeleteZone(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        private bool ZoneExists(int id)
        {
            return _context.Zones.Any(e => e.Id == id);
        }
    }
}
