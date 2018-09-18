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
    public class IndexModel : PageModel
    {
        private readonly StartSvc.Models.StartSvcContext _context;

        public IndexModel(StartSvc.Models.StartSvcContext context)
        {
            _context = context;
        }

        public IList<StartRecord> StartRecord { get;set; }

        public async Task OnGetAsync()
        {
            StartRecord = await _context.StartRecord.ToListAsync();
        }
    }
}
