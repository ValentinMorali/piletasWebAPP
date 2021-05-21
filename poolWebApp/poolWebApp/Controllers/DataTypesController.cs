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
    public class DataTypesController : ControllerBase
    {
        private readonly Level3_SM_WastePoolContext _context;

        public DataTypesController(Level3_SM_WastePoolContext context)
        {
            _context = context;
        }

        // GET: api/DataTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataType>>> GetDataTypes()
        {
            return await _context.DataTypes.ToListAsync();
        }

        // GET: api/DataTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataType>> GetDataType(int id)
        {
            var dataType = await _context.DataTypes.FindAsync(id);

            if (dataType == null)
            {
                return NotFound();
            }

            return dataType;
        }

        // PUT: api/DataTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataType(int id, DataType dataType)
        {
            if (id != dataType.IdDataType)
            {
                return BadRequest();
            }

            _context.Entry(dataType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataTypeExists(id))
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

        // POST: api/DataTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataType>> PostDataType(DataType dataType)
        {
            _context.DataTypes.Add(dataType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataType", new { id = dataType.IdDataType }, dataType);
        }

        // DELETE: api/DataTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataType(int id)
        {
            var dataType = await _context.DataTypes.FindAsync(id);
            if (dataType == null)
            {
                return NotFound();
            }

            _context.DataTypes.Remove(dataType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataTypeExists(int id)
        {
            return _context.DataTypes.Any(e => e.IdDataType == id);
        }
    }
}
