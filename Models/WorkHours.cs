using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class WorkHours : BaseModel
    {
        public WorkHours()
        {
            UsersWorkHours = new HashSet<UsersWorkHours>();
            WorkHoursBreaks = new HashSet<WorkHoursBreaks>();
        }

        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartTime { get; set; }

        public ICollection<UsersWorkHours> UsersWorkHours { get; set; }
        public ICollection<WorkHoursBreaks> WorkHoursBreaks { get; set; }

        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.WorkHours.Add(this).State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }
        public static WorkHours get(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.WorkHours.Find(id);
            }
        }
        public static List<WorkHours> list()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.WorkHours.ToList();
            }
        }
        public static void edit(uint id, WorkHours changes)
        {
            WorkHours workHoursOrig = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Entry(workHoursOrig).CurrentValues.SetValues(changes);
                dbContext.Entry(workHoursOrig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public static void delete(uint id)
        {
            var workHours = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                workHours.DeletedAt = DateTime.Now;
                dbContext.Entry(workHours).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
