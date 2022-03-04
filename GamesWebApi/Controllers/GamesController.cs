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
    public class GamesController : ControllerBase
    {
        private readonly Db_GamesContext _context;

        public GamesController(Db_GamesContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGames>>> GetTbGames()
        {
            return await _context.TbGames.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGames>> GetTbGames(int id)
        {
            var tbGames = await _context.TbGames.FindAsync(id);

            if (tbGames == null)
            {
                return NotFound();
            }

            return tbGames;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGames(int id, TbGames tbGames)
        {
            if (id != tbGames.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGamesExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbGames>> PostTbGames(TbGames tbGames)
        {
            _context.TbGames.Add(tbGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbGames", new { id = tbGames.Id }, tbGames);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGames(int id)
        {
            var tbGames = await _context.TbGames.FindAsync(id);
            if (tbGames == null)
            {
                return NotFound();
            }

            _context.TbGames.Remove(tbGames);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGamesExists(int id)
        {
            return _context.TbGames.Any(e => e.Id == id);
        }
    }
}
