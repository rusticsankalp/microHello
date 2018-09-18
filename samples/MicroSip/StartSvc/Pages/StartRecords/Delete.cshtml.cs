using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StartSvc.Models;

namespace StartSvc.Pages.StartRecords
{
    public class DeleteModel : PageModel
    {
        private readonly StartSvc.Models.StartSvcContext _context;

        public DeleteModel(StartSvc.Models.StartSvcContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StartRecord = await _context.StartRecord.FindAsync(id);

            if (StartRecord != null)
            {
                _context.StartRecord.Remove(StartRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
