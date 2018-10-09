using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class Breaks : BaseModel
    {
        public Breaks()
        {
            WorkHoursBreaks = new HashSet<WorkHoursBreaks>();
        }

        public uint Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<WorkHoursBreaks> WorkHoursBreaks { get; set; }

        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Breaks.Add(this);
                dbContext.SaveChanges();
            }
        }

        public static Breaks get(uint id)
        {
            Breaks brk;
            using (var dbCOntext = new WashingtonRedskinsContext())
            {
                brk = dbCOntext.Breaks.Find(id);
            }
            return brk;
        }

        public static List<Breaks> list(int pageSize = 50,
            int skip = 0)
        {
            IQueryable<Breaks> dbBreaks;
            List<Breaks> brks;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbBreaks = dbContext.Breaks;

                if (pageSize != 0)
                {
                    dbBreaks = dbBreaks.Take(pageSize);
                }
                if (skip != 0)
                {
                    dbBreaks = dbBreaks.Skip(skip);
                }
            brks = dbBreaks.ToList();
            }
            return brks;
        }
        public static void edit(uint id, Breaks changes)
        {
            var orig = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Entry(orig).CurrentValues.SetValues(changes);
                dbContext.Entry(orig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public static void delete(uint id)
        {
            var brk = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                brk.DeletedAt = DateTime.Now;
                dbContext.Entry(brk).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}