using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartSvc.Models;

namespace StartSvc.Pages.StartRecords
{
    public class EditModel : PageModel
    {
        private readonly StartSvc.Models.StartSvcContext _context;

        public EditModel(StartSvc.Models.StartSvcContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StartRecord StartRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StartRecord = await _context.StartRecord.FirstOrDefaultAsync(m => m.ID == id);

            if (StartRecord == null)
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

            _context.Attach(StartRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StartRecordExists(StartRecord.ID))
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

        private bool StartRecordExists(int id)
        {
            return _context.StartRecord.Any(e => e.ID == id);
        }
    }
}
