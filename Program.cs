using System;
using Grapevine.Server;
using System.Linq;

namespace WashingtonRedskins
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Where(a => a == "seed") != null)
            {
                Seed.Seed.seed();
                ScheduledJobs.StatisticsJobs.run(DateTime.Parse("1970-01-01 00:00:00"));
            }

            using (RestServer server = new RestServer())
            {
                server.LogToConsole().Start();
                Console.ReadLine();
            }
        }
    }
}
