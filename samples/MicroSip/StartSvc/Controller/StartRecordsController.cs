using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartSvc.Models;

namespace StartSvc.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartRecordsController : ControllerBase
    {
        private readonly StartSvcContext _context;

        public StartRecordsController(StartSvcContext context)
        {
            _context = context;
        }

        // GET: api/StartRecords
        [HttpGet]
        public IEnumerable<StartRecord> GetStartRecord()
        {
            return _context.StartRecord;
        }

        // GET: api/StartRecords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStartRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var startRecord = await _context.StartRecord.FindAsync(id);

            if (startRecord == null)
            {
                return NotFound();
            }

            return Ok(startRecord);
        }

        // PUT: api/StartRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStartRecord([FromRoute] int id, [FromBody] StartRecord startRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != startRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(startRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StartRecordExists(id))
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

        // POST: api/StartRecords
        //[HttpPost]
        //public async Task<IActionResult> PostStartRecord([FromBody] StartRecord startRecord)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.StartRecord.Add(startRecord);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStartRecord", new { id = startRecord.ID }, startRecord);
        //}

        [HttpPost]
        public  IEnumerable<StartRecord> PostStartRecord([FromHeader] int reqNum)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            StartRecord[] stRecArray = new StartRecord[3]; 
            for (int i =0; i<3;i++)
            {
                stRecArray[i] = new StartRecord{ Value = 40000+i};
                _context.StartRecord.Add(stRecArray[i]);
            }
            _context.SaveChangesAsync();

            return stRecArray;
        }

        // DELETE: api/StartRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStartRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var startRecord = await _context.StartRecord.FindAsync(id);
            if (startRecord == null)
            {
                return NotFound();
            }

            _context.StartRecord.Remove(startRecord);
            await _context.SaveChangesAsync();

            return Ok(startRecord);
        }

        private bool StartRecordExists(int id)
        {
            return _context.StartRecord.Any(e => e.ID == id);
        }
    }
}