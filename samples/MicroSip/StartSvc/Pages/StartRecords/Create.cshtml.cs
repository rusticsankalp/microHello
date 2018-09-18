using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartSvc.Models;

namespace StartSvc.Pages.StartRecords
{
    public class CreateModel : PageModel
    {
        private readonly StartSvc.Models.StartSvcContext _context;

        public CreateModel(StartSvc.Models.StartSvcContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StartRecord StartRecord { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StartRecord.Add(StartRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}