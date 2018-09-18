using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiddleService.Models;

namespace MiddleService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddleRecordsController : ControllerBase
    {
        private readonly MiddleServiceContext _context;

        public MiddleRecordsController(MiddleServiceContext context)
        {
            _context = context;
        }

        // GET: api/MiddleRecords
        [HttpGet]
        public IEnumerable<MiddleRecord> GetMiddleRecord()
        {
            return _context.MiddleRecord;
        }

        // GET: api/MiddleRecords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMiddleRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var middleRecord = await _context.MiddleRecord.FindAsync(id);

            if (middleRecord == null)
            {
                return NotFound();
            }

            return Ok(middleRecord);
        }

        // PUT: api/MiddleRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiddleRecord([FromRoute] int id, [FromBody] MiddleRecord middleRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != middleRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(middleRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiddleRecordExists(id))
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

        // POST: api/MiddleRecords
        [HttpPost]
        public async Task<IActionResult> PostMiddleRecord([FromBody] MiddleRecord middleRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MiddleRecord.Add(middleRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiddleRecord", new { id = middleRecord.ID }, middleRecord);
        }

        // DELETE: api/MiddleRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiddleRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var middleRecord = await _context.MiddleRecord.FindAsync(id);
            if (middleRecord == null)
            {
                return NotFound();
            }

            _context.MiddleRecord.Remove(middleRecord);
            await _context.SaveChangesAsync();

            return Ok(middleRecord);
        }

        private bool MiddleRecordExists(int id)
        {
            return _context.MiddleRecord.Any(e => e.ID == id);
        }
    }
}