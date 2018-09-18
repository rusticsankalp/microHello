using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiddleService.Models;

namespace MiddleService.Pages.MiddleRecords
{
    public class DeleteModel : PageModel
    {
        private readonly MiddleService.Models.MiddleServiceContext _context;

        public DeleteModel(MiddleService.Models.MiddleServiceContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MiddleRecord = await _context.MiddleRecord.FindAsync(id);

            if (MiddleRecord != null)
            {
                _context.MiddleRecord.Remove(MiddleRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
