using System.Linq;
using WashingtonRedskins.Models;

namespace WashingtonRedskins.ScheduledJobs
{
    class Scheduler
    {
        public void run()
        {
            RegistrationsEdits regEdit;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                regEdit = dbContext.RegistrationsEdits.First();
            }
            StatisticsJobs.run(regEdit.Time ?? null);
        }
    }
}