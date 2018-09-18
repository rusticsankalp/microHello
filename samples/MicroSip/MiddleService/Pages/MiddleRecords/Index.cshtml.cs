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
    public class IndexModel : PageModel
    {
        private readonly MiddleService.Models.MiddleServiceContext _context;

        public IndexModel(MiddleService.Models.MiddleServiceContext context)
        {
            _context = context;
        }

        public IList<MiddleRecord> MiddleRecord { get;set; }

        public async Task OnGetAsync()
        {
            MiddleRecord = await _context.MiddleRecord.ToListAsync();
        }
    }
}
