using System;
using System.Threading.Tasks;

namespace ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RunAsync().GetAwaiter().GetResult();
            
        }

        static async Task RunAsync()
        {
            StartSvcClient stsvc = new StartSvcClient("https://localhost:44378/");
            StartRecord stRec = await stsvc.GetStartRecordAsync(1);

            StartRecord stRec2 = new StartRecord { Value = 3002 };
            StartRecord stRec3 = await stsvc.CreateStartRecordAsync(stRec2);

        }
    }
}
