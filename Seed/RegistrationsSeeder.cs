using System;
using System.Collections.Generic;
using System.Text;
using WashingtonRedskins.Models;

namespace WashingtonRedskins.Seed
{
    static class RegistrationsSeeder
    {
        static uint currentStatus = 0;
        static int counter = 1;
        static DateTime startTime = DateTime.Parse("30-01-2017 08:00:00");
        static DateTime endTime = startTime.AddYears(1);

        private static uint getNextStatus(uint status = 0)
        {
            if (status == 0)
            {
                return currentStatus = 1;
            }

            Statuses stat = new Statuses();
            stat.Id = status;


            var statuses = stat.getValidStatuschanges();

            while (counter >= statuses.Count)
            {
                counter = counter % 8;
                counter++;
            }
            currentStatus = statuses[counter];
            
            return statuses[counter];
        }

        public static void run()
        {
            List<Registrations> myRegs = new List<Registrations>();
            var myTime = startTime;

            for (uint i = 1; i < 5; i++)
            {
                while (myTime <= endTime)
                {
                    if(myTime.Month == 3 && myTime.Day == 26 && myTime.Hour == 2)
                    {
                        myTime = myTime.AddHours(1);
                    }
                    myRegs.Add(new Registrations { UserId = i, StatusId = getNextStatus(currentStatus), Time = myTime, DepartmentId = i % 2 });
                    myTime = myTime.AddHours(1);
                    counter++;
                }
            }

            using (var dbContext = new WashingtonRedskinsContext())
            {
                foreach(Registrations r in myRegs)
                {
                    dbContext.Add(r);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
