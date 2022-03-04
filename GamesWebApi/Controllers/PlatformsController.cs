#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamesWebApi.Data;
using GamesWebApi.Models;

namespace GamesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly Db_GamesContext _context;

        public PlatformsController(Db_GamesContext context)
        {
            _context = context;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPlatform>>> GetTbPlatform()
        {
            return await _context.TbPlatform.ToListAsync();
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPlatform>> GetTbPlatform(int id)
        {
            var tbPlatform = await _context.TbPlatform.FindAsync(id);

            if (tbPlatform == null)
            {
                return NotFound();
            }

            return tbPlatform;
        }

        // PUT: api/Platforms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPlatform(int id, TbPlatform tbPlatform)
        {
            if (id != tbPlatform.Idplatform)
            {
                return BadRequest();
            }

            _context.Entry(tbPlatform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPlatformExists(id))
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

        // POST: api/Platforms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPlatform>> PostTbPlatform(TbPlatform tbPlatform)
        {
            _context.TbPlatform.Add(tbPlatform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPlatform", new { id = tbPlatform.Idplatform }, tbPlatform);
        }

        // DELETE: api/Platforms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPlatform(int id)
        {
            var tbPlatform = await _context.TbPlatform.FindAsync(id);
            if (tbPlatform == null)
            {
                return NotFound();
            }

            _context.TbPlatform.Remove(tbPlatform);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPlatformExists(int id)
        {
            return _context.TbPlatform.Any(e => e.Idplatform == id);
        }
    }
}
