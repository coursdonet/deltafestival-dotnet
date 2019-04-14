using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Geo.Geometry;
using WebApi.Geo.Feature;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Database;
using Entities;
using System.IO;  
using System.Runtime.Serialization.Json; 

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly MapContext _context;

        private FeatureCollection ZonesJson = new FeatureCollection();
        private Feature Zone;

        public ZoneController(MapContext context) => _context = context;


        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZones()
        {

            ZonesJson = LoadZonesJson();

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

            ZonesJson = LoadZonesJson();
            for (int i = ZonesJson.Features.Count(); i-- > 0;)
                if (ZonesJson.Features[i].Id == id.ToString())
                {
                   Zone = ZonesJson.Features[i];
                }
            

            return zone;
        }

        // POST: api/Zones
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone, List<LineString> lines)
        {
            _context.Zones.Add(zone);
            await _context.SaveChangesAsync();

            ZonesJson = LoadZonesJson();
            for (int i = ZonesJson.Features.Count(); i-- > 0;)
                if (ZonesJson.Features[i].Id == zone.Id.ToString())
                {
                    FeatureCollectionZonesSerialization(lines, zone.Id);
                }


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

            ZonesJson = LoadZonesJson();
            for (int i = ZonesJson.Features.Count(); i-- > 0;)
                if (ZonesJson.Features[i].Id == id.ToString())
                {
                    ZonesJson.Features[i] = null;

                }

            var actualJson = JsonConvert.SerializeObject(ZonesJson, Formatting.Indented);

            System.IO.File.WriteAllText("..\\JsonFiles\\Zones.json", actualJson);

            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        private bool ZoneExists(int id)
        {
            return _context.Zones.Any(e => e.Id == id);
        }

        private FeatureCollection LoadZonesJson()
        {
            using (StreamReader r = new StreamReader("..\\JsonFiles\\Zones.json"))
            {
                string json = r.ReadToEnd();
                FeatureCollection zones = JsonConvert.DeserializeObject<FeatureCollection>(json);
                return zones;
            }
        }

        private void FeatureCollectionZonesSerialization(List<LineString> lines, int id)
        {
            var model = LoadZonesJson();
                        
            var geom = new Polygon(lines);

            var feature = new Feature(geom, id.ToString());

            model.Features.Add(feature);

            var actualJson = JsonConvert.SerializeObject(model, Formatting.Indented);

            System.IO.File.WriteAllText("..\\JsonFiles\\Zones.json", actualJson);
        }


    }
}
