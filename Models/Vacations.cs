using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class Vacations : BaseModel
    {
        public Vacations()
        {
            UsersVacations = new HashSet<UsersVacations>();
        }

        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime End { get; set; }
        public DateTime Start { get; set; }
        public string Name { get; set; }

        public ICollection<UsersVacations> UsersVacations { get; set; }
        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Vacations.Add(this).State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }
        public static Vacations get(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.Vacations.Find(id);
            }
        }
        public static List<Vacations> list(int pageSize = 50,
           int skip = 0)
        {
            IQueryable<Vacations> dbVacations;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbVacations = dbContext.Vacations;

                if (pageSize != 0)
                {
                    dbVacations = dbVacations.Take(pageSize);
                }
                if (skip != 0)
                {
                    dbVacations = dbVacations.Skip(skip);
                }
                return dbVacations.ToList();
            }
        }

        public static void edit(uint id, Vacations changes)
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
            var vac = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                vac.DeletedAt = DateTime.Now;
                dbContext.Entry(vac).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

    }
}
