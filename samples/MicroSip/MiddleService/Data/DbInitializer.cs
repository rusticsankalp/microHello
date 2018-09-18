using MiddleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleService.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MiddleServiceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any existing records.
            if (context.MiddleRecord.Any())
            {
                return;   // DB has been seeded
            }

            var startRecords = new MiddleRecord[]
            {
            new MiddleRecord{Value=2001},
            new MiddleRecord{Value=2002},
            new MiddleRecord{Value=2003},
            new MiddleRecord{Value=2004},
            new MiddleRecord{Value=2005}

            };
            foreach (MiddleRecord s in startRecords)
            {
                context.MiddleRecord.Add(s);
            }
            context.SaveChanges();


        }
    }
}
