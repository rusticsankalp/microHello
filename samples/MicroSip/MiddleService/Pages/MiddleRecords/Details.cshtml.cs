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
    public class DetailsModel : PageModel
    {
        private readonly MiddleService.Models.MiddleServiceContext _context;

        public DetailsModel(MiddleService.Models.MiddleServiceContext context)
        {
            _context = context;
        }

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
    }
}
