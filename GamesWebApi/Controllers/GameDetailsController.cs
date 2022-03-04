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
    public class GameDetailsController : ControllerBase
    {
        private readonly Db_GamesContext _context;

        public GameDetailsController(Db_GamesContext context)
        {
            _context = context;
        }

        // GET: api/GameDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDetails>>> GetGameDetails()
        {
            return await _context.GameDetails.ToListAsync();
        }

        // GET: api/GameDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDetails>> GetGameDetails(int id)
        {
            var gameDetails = await _context.GameDetails.FindAsync(id);

            if (gameDetails == null)
            {
                return NotFound();
            }

            return gameDetails;
        }

        // PUT: api/GameDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameDetails(int id, GameDetails gameDetails)
        {
            if (id != gameDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameDetailsExists(id))
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

        // POST: api/GameDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameDetails>> PostGameDetails(GameDetails gameDetails)
        {
            _context.GameDetails.Add(gameDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameDetailsExists(gameDetails.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGameDetails", new { id = gameDetails.Id }, gameDetails);
        }

        // DELETE: api/GameDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameDetails(int id)
        {
            var gameDetails = await _context.GameDetails.FindAsync(id);
            if (gameDetails == null)
            {
                return NotFound();
            }

            _context.GameDetails.Remove(gameDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameDetailsExists(int id)
        {
            return _context.GameDetails.Any(e => e.Id == id);
        }
    }
}
