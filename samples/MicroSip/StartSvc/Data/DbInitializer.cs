using StartSvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StartSvcContext context)
        {
            context.Database.EnsureCreated();

            // Look for any existing records.
            if (context.StartRecord.Any())
            {
                return;   // DB has been seeded
            }

            var startRecords = new StartRecord[]
            {
            new StartRecord{Value=1001},
            new StartRecord{Value=1002},
            new StartRecord{Value=1003},
            new StartRecord{Value=1004},
            new StartRecord{Value=1005}

            };
            foreach (StartRecord s in startRecords)
            {
                context.StartRecord.Add(s);
            }
            context.SaveChanges();

          
        }
    }
}
