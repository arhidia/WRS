using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class Registrations : BaseModel
    {
        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public uint StatusId { get; set; }
        public DateTime Time { get; set; }
        public uint UserId { get; set; }
        public uint? DepartmentId { get; set; }

        public Statuses Status { get; set; }
        public Users User { get; set; }
        public Departments Department { get; set; }

        public static void add(uint userId, uint statusId)
        {
            Registrations reg = new Registrations();

            Users usr;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                usr = dbContext.Users.Find(userId);
            }

            reg.UserId = userId;
            reg.Time = DateTime.Now;
            reg.DepartmentId = usr.DepartmentId;
            reg.StatusId = statusId;

            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Add(reg);
                dbContext.SaveChanges();
            }
        }

        public static Registrations get(uint id)
        {
            using (var dbCOntext = new WashingtonRedskinsContext())
            {
                return dbCOntext.Registrations.Find(id);
            }
        }

        public static List<Registrations> list(DateTime start, int pageSize,
            int skip, uint userId)
        {
            IQueryable<Registrations> dbRegs;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbRegs = dbContext.Registrations;

                if (start != null)
                {
                    dbRegs = dbRegs.Where(r => r.Time > start);
                }
                if (pageSize != 0)
                {
                    dbRegs = dbRegs.Take(pageSize + skip);
                }
                if (skip != 0)
                {
                    dbRegs = dbRegs.Skip(skip);
                }
                if (userId != 0)
                {
                    dbRegs = dbRegs.Where(r => r.UserId == userId);
                }
            return dbRegs.ToList();
            }
        }

        public static void edit(Registrations newRegistration, uint origId)
        {
            var orig = get(origId);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Entry(orig).CurrentValues.SetValues(newRegistration);
                dbContext.Entry(orig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            var earliestTime = newRegistration.Time < orig.Time ? newRegistration.Time : orig.Time;

            RegistrationsEdits.set(earliestTime);
        }

        public static void delete(uint id)
        {
            DateTime time;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                time = dbContext.Registrations.Find(id).Time;
                dbContext.Registrations.Find(id).DeletedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            RegistrationsEdits.set(time);
        }

        public Registrations getPrevious()
        {
            Registrations reg;

            try
            {
                using (var dbContext = new WashingtonRedskinsContext())
                {
                    reg = dbContext.Registrations.Where(r => r.UserId == UserId).Where(r => r.Id < Id).OrderByDescending(r => r.Id).First();
                }
            }
            catch
            {
                reg = null;
            }
            return reg;
        }
    }
}
