using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using poolWebApp.Models;

namespace poolWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoolsController : ControllerBase
    {
        private readonly Level3_SM_WastePoolContext _context;

        public PoolsController(Level3_SM_WastePoolContext context)
        {
            _context = context;
        }

        // GET: api/Pools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pool>>> GetPools()
        {
            return await _context.Pools.ToListAsync();
        }

        // GET: api/Pools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pool>> GetPool(int id)
        {
            var pool = await _context.Pools.FindAsync(id);

            if (pool == null)
            {
                return NotFound();
            }

            return pool;
        }

        // PUT: api/Pools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPool(int id, Pool pool)
        {
            if (id != pool.IdPool)
            {
                return BadRequest();
            }

            _context.Entry(pool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolExists(id))
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

        // POST: api/Pools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pool>> PostPool(Pool pool)
        {
            _context.Pools.Add(pool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPool", new { id = pool.IdPool }, pool);
        }

        // DELETE: api/Pools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePool(int id)
        {
            var pool = await _context.Pools.FindAsync(id);
            if (pool == null)
            {
                return NotFound();
            }

            _context.Pools.Remove(pool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoolExists(int id)
        {
            return _context.Pools.Any(e => e.IdPool == id);
        }
    }
}
