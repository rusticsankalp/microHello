using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiddleService.Models
{
    public class MiddleServiceContext : DbContext
    {
        public MiddleServiceContext (DbContextOptions<MiddleServiceContext> options)
            : base(options)
        {
        }

        public DbSet<MiddleService.Models.MiddleRecord> MiddleRecord { get; set; }
    }
}
