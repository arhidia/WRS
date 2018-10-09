using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class Privileges : BaseModel
    {
        public Privileges()
        {
            UserGroupsPrivileges = new HashSet<UserGroupsPriviliges>();
        }

        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Name { get; set; }

        public ICollection<UserGroupsPriviliges> UserGroupsPrivileges { get; set; }

        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Privileges.Add(this);
                dbContext.SaveChanges();
            }
        }

        private static Privileges get(uint id)
        {
            using (var dbCOntext = new WashingtonRedskinsContext())
            {
                return dbCOntext.Privileges.Find(id);
            }
        }

        public static List<Privileges> list()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.Privileges.ToList();
            }
        }

        public static void edit(uint id, Privileges newPrivilege)
        {
            var orig = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Entry(orig).CurrentValues.SetValues(newPrivilege);
                dbContext.Entry(orig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public static void delete(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Remove(dbContext.Privileges.Find(id));
            }
        }
    }
}
