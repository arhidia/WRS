using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class Departments : BaseModel
    {
        public Departments()
        {
            RegistrationSummary = new HashSet<RegistrationSummary>();
            Users = new HashSet<Users>();
        }

        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Name { get; set; }

        public ICollection<RegistrationSummary> RegistrationSummary { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<Registrations> Registrations { get; set; }

        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Departments.Add(this);
                dbContext.SaveChanges();
            }
        }

        public static Departments get(uint id)
        {
            using (var dbCOntext = new WashingtonRedskinsContext())
            {
                return dbCOntext.Departments.Find(id);
            }
        }

        public static List<Departments> list(int pageSize = 50, int skip = 0)
        {
            IQueryable<Departments> dbDepartments;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbDepartments = dbContext.Departments;

                if (pageSize != 0)
                {
                    dbDepartments = dbDepartments.Take(pageSize);
                }
                if (skip != 0)
                {
                    dbDepartments = dbDepartments.Skip(skip);
                }
                return dbDepartments.ToList();
            }
        }


        public static void edit(uint id, Departments newDepartment)
        {
            var orig = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Entry(orig).CurrentValues.SetValues(newDepartment);
                dbContext.Entry(orig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public static void delete(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                var orig = dbContext.Departments.Find(id);
                orig.DeletedAt = DateTime.Now;
                bool a = dbContext.ChangeTracker.HasChanges(); //double check if there was any change detected by EF or not?
                dbContext.SaveChanges();
            }
        }
    }
}
