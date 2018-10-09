using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class UserGroup : BaseModel
    {
        public UserGroup()
        {
            UserGroupsPrivileges = new HashSet<UserGroupsPriviliges>();
            Users = new HashSet<Users>();
        }

        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Name { get; set; }

        public ICollection<UserGroupsPriviliges> UserGroupsPrivileges { get; set; }
        public ICollection<Users> Users { get; set; }

        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.UserGroups.Add(this).State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }
        public static UserGroup get(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.UserGroups.Find(id);
            }
        }
        public static List<UserGroup> list(int pageSize = 50,
                 int skip = 0)
        {
            IQueryable<UserGroup> dbUserGroups;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbUserGroups = dbContext.UserGroups;

                if (pageSize != 0)
                {
                    dbUserGroups = dbUserGroups.Take(pageSize);
                }
                if (skip != 0)
                {
                    dbUserGroups = dbUserGroups.Skip(skip);
                }
            return dbUserGroups.ToList();
            }
        }


        public static void edit(UserGroup changes, uint id)
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
            var orig = get(id);
            using (var dbContext = new WashingtonRedskinsContext())
            {
                orig.DeletedAt = DateTime.Now;
                dbContext.Entry(orig).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
