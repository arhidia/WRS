using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class Statuses : BaseModel
    {
        public Statuses()
        {
            RegistrationSummary = new HashSet<RegistrationSummary>();
            Registrations = new HashSet<Registrations>();
        }

        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Name { get; set; }

        public ICollection<RegistrationSummary> RegistrationSummary { get; set; }
        public ICollection<Registrations> Registrations { get; set; }

        public List<uint> getValidStatuschanges()
        {
            List<uint> statuses = new List<uint>();

            switch (Id)
            {
                case 1:
                    statuses.Add(2);
                    statuses.Add(3);
                    statuses.Add(4);
                    statuses.Add(5);
                    statuses.Add(6);
                    statuses.Add(7);
                    break;
                case 2:
                    statuses.Add(1);
                    statuses.Add(3);
                    statuses.Add(4);
                    statuses.Add(6);
                    statuses.Add(7);
                    break;
                case 3:
                    statuses.Add(1);
                    statuses.Add(2);
                    statuses.Add(4);
                    statuses.Add(6);
                    statuses.Add(7);
                    break;
                case 4:
                    statuses.Add(1);
                    statuses.Add(2);
                    statuses.Add(3);
                    statuses.Add(6);
                    statuses.Add(7);
                    break;
                case 5:
                    statuses.Add(1);
                    statuses.Add(3);
                    statuses.Add(4);
                    statuses.Add(6);
                    statuses.Add(7);
                    statuses.Add(8);
                    break;
                case 6:
                    statuses.Add(1);
                    statuses.Add(2);
                    statuses.Add(3);
                    statuses.Add(7);
                    statuses.Add(8);
                    break;
                case 7:
                    statuses.Add(1);
                    statuses.Add(2);
                    statuses.Add(3);
                    statuses.Add(4);
                    statuses.Add(6);
                    statuses.Add(8);
                    break;
                case 8:
                    statuses.Add(1);
                    statuses.Add(2);
                    statuses.Add(3);
                    statuses.Add(4);
                    statuses.Add(6);
                    statuses.Add(7);
                    break;
            }
            return statuses;
        }
        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Statuses.Add(this);
                dbContext.SaveChanges();
            }
        }

        private static Statuses get(uint id)
        {
            using (var dbCOntext = new WashingtonRedskinsContext())
            {
                return dbCOntext.Statuses.Find(id);
            }
        }

        public static List<Statuses> list()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.Statuses.ToList();
            }
        }

        public static void edit(uint id, Statuses newStatus)
        {
            var orig = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Entry(orig).CurrentValues.SetValues(newStatus);
                dbContext.Entry(orig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public static void delete(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Remove(dbContext.Statuses.Find(id));
            }
        }
    }
}
