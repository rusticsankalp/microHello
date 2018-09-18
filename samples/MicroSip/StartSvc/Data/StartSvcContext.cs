using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StartSvc.Models
{
    public class StartSvcContext : DbContext
    {
        public StartSvcContext (DbContextOptions<StartSvcContext> options)
            : base(options)
        {
        }

        public DbSet<StartSvc.Models.StartRecord> StartRecord { get; set; }
    }
}
