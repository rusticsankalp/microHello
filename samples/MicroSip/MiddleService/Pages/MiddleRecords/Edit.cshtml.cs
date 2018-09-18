using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiddleService.Models;

namespace MiddleService.Pages.MiddleRecords
{
    public class EditModel : PageModel
    {
        private readonly MiddleService.Models.MiddleServiceContext _context;

        public EditModel(MiddleService.Models.MiddleServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MiddleRecord MiddleRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MiddleRecord = await _context.MiddleRecord.FirstOrDefaultAsync(m => m.ID == id);

            if (MiddleRecord == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MiddleRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiddleRecordExists(MiddleRecord.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MiddleRecordExists(int id)
        {
            return _context.MiddleRecord.Any(e => e.ID == id);
        }
    }
}
