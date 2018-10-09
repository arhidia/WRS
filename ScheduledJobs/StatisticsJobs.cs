using System;
using System.Collections.Generic;
using System.Linq;
using WashingtonRedskins.Extensions;
using WashingtonRedskins.Models;

namespace WashingtonRedskins.ScheduledJobs
{
    class StatisticsJobs
    {
        private static DateTime date = new DateTime();
        private static uint currentUser = 0;
        private static Registrations lastReg = new Registrations();
        private static DateTime currentTime = DateTime.Now.setToMidnight();
        private static List<Registrations> regs;
        private static List<RegistrationSummary> regSummary;

        private static List<Statuses> statuses;

        public static void run(DateTime? start = null)

        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.RegistrationsEdits.First().Time = DateTime.Now.AddDays(1);
                dbContext.SaveChanges();
            }

            if (start != null)
            {
                currentTime = (DateTime)start;
                currentTime.setToMidnight();
            }
            calculateDaily(currentTime);
        }

        private static void calculateDaily(DateTime start)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                statuses = dbContext.Statuses.ToList();

                regs = dbContext.Registrations.Where(r => r.Time >= start)
                    .OrderBy(r => r.UserId).ThenBy(r => r.Time).ToList();
            }
            regSummary = new List<RegistrationSummary>();
            foreach (Registrations r in regs)
            {
                if (currentUser != r.UserId || date.Date != r.Time.Date)
                {
                    if (currentUser != r.UserId)
                    {
                        changeUser(r);
                    }
                    else
                    {
                        changeDay(r);
                    }
                }
                else
                {
                    if (regSummary == null)
                    {
                        initList(r);
                    }
                    regSummary.Where(d => d.StatusId == r.StatusId).First().Duration +=
                        (r.Time - lastReg.Time).toSeconds();
                }
                currentUser = r.UserId;
                date = r.Time;
                lastReg = r;
            }
            using (var dbContext = new WashingtonRedskinsContext())
            {
                var time = dbContext.RegistrationsEdits.First().Time;
                if ( time < DateTime.Now)
                {
                    run(time);
                }
            }
        }


        private static void changeDay(Registrations r)
        {
            regSummary.Where(s => s.StatusId == lastReg.StatusId).First().Duration +=
                (date.AddDays(1).setToMidnight() - lastReg.Time).toSeconds();
            saveRegistrations();
            initList(r);
            regSummary.Where(s => s.StatusId == r.StatusId).First().Duration +=
                (r.Time - date.AddDays(1).setToMidnight()).toSeconds();
        }

        private static void changeUser(Registrations r)
        {
            if (regSummary.Count > 0)
            {
                regSummary.Where(d => r.StatusId == lastReg.StatusId).First().Duration +=
                    (lastReg.Time.setToMidnight().AddDays(1) - lastReg.Time).toSeconds();
                saveRegistrations();
            }
            initList(r);

            var previous = r.getPrevious();
            if (previous != null)
            {
                regSummary.Where(d => d.StatusId == previous.StatusId).First()
                    .Duration += (currentTime.AddDays(-1) - r.Time).toSeconds();
            }
        }

        private static void saveRegistrations()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                foreach (RegistrationSummary r in regSummary)
                {
                    dbContext.Add(r);
                }
                dbContext.SaveChanges();
            }
            regSummary = null;
        }

        private static void initList(Registrations r)
        {
            regSummary = new List<RegistrationSummary>();
            foreach (Statuses s in statuses)
            {
                regSummary.Add(new RegistrationSummary
                {
                    StatusId = s.Id,
                    DepartmentId = r.DepartmentId,
                    UserId = r.UserId,
                    Date = r.Time.Date,
                    YearMonth = r.Time.Year * 100 + r.Time.Month,
                    YearWeek = r.Time.weekOfYear(),
                });
            }
        }
    }
}
