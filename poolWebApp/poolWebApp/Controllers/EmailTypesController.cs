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
    public class EmailTypesController : ControllerBase
    {
        private readonly Level3_SM_WastePoolContext _context;

        public EmailTypesController(Level3_SM_WastePoolContext context)
        {
            _context = context;
        }

        // GET: api/EmailTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailType>>> GetEmailTypes()
        {
            return await _context.EmailTypes.ToListAsync();
        }

        // GET: api/EmailTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailType>> GetEmailType(long id)
        {
            var emailType = await _context.EmailTypes.FindAsync(id);

            if (emailType == null)
            {
                return NotFound();
            }

            return emailType;
        }

        // PUT: api/EmailTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailType(long id, EmailType emailType)
        {
            if (id != emailType.IdEmailType)
            {
                return BadRequest();
            }

            _context.Entry(emailType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailTypeExists(id))
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

        // POST: api/EmailTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailType>> PostEmailType(EmailType emailType)
        {
            _context.EmailTypes.Add(emailType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailType", new { id = emailType.IdEmailType }, emailType);
        }

        // DELETE: api/EmailTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailType(long id)
        {
            var emailType = await _context.EmailTypes.FindAsync(id);
            if (emailType == null)
            {
                return NotFound();
            }

            _context.EmailTypes.Remove(emailType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailTypeExists(long id)
        {
            return _context.EmailTypes.Any(e => e.IdEmailType == id);
        }
    }
}
