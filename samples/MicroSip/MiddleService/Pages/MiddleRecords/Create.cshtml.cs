using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiddleService.Models;

namespace MiddleService.Pages.MiddleRecords
{
    public class CreateModel : PageModel
    {
        private readonly MiddleService.Models.MiddleServiceContext _context;

        public CreateModel(MiddleService.Models.MiddleServiceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MiddleRecord MiddleRecord { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MiddleRecord.Add(MiddleRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}