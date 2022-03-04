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
    public class GenresController : ControllerBase
    {
        private readonly Db_GamesContext _context;

        public GenresController(Db_GamesContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGenre>>> GetTbGenre()
        {
            return await _context.TbGenre.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGenre>> GetTbGenre(int id)
        {
            var tbGenre = await _context.TbGenre.FindAsync(id);

            if (tbGenre == null)
            {
                return NotFound();
            }

            return tbGenre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGenre(int id, TbGenre tbGenre)
        {
            if (id != tbGenre.Idgenre)
            {
                return BadRequest();
            }

            _context.Entry(tbGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGenreExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbGenre>> PostTbGenre(TbGenre tbGenre)
        {
            _context.TbGenre.Add(tbGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbGenre", new { id = tbGenre.Idgenre }, tbGenre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGenre(int id)
        {
            var tbGenre = await _context.TbGenre.FindAsync(id);
            if (tbGenre == null)
            {
                return NotFound();
            }

            _context.TbGenre.Remove(tbGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGenreExists(int id)
        {
            return _context.TbGenre.Any(e => e.Idgenre == id);
        }
    }
}
