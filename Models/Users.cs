using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WashingtonRedskins.Controllers;

namespace WashingtonRedskins.Models
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            RegistrationSummary = new HashSet<RegistrationSummary>();
            Registrations = new HashSet<Registrations>();
            UsersVacations = new HashSet<UsersVacations>();
            UsersWorkHours = new HashSet<UsersWorkHours>();
        }

        public uint Id { get; set; }
        public string Address { get; set; }
        public int CprNr { get; set; }
        public DateTime? DeletedAt { get; set; }
        public uint? DepartmentId { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Postcode { get; set; }
        public uint? UserGroupId { get; set; }

        public Departments Department { get; set; }
        public UserGroup UserGroup { get; set; }
        public ICollection<RegistrationSummary> RegistrationSummary { get; set; }
        public ICollection<Registrations> Registrations { get; set; }
        public ICollection<UsersVacations> UsersVacations { get; set; }
        public ICollection<UsersWorkHours> UsersWorkHours { get; set; }

        public List<string> GetUserPrivileges()
        {
            IQueryable<string> privileges;
            using (var dbcontext = new WashingtonRedskinsContext())
            {
                privileges = dbcontext.Privileges.Where(x => x.UserGroupsPrivileges.Where(up => up.Isallowed == 1).Any(r => r.UserGroup.Id == UserGroupId)).Select(p => p.Name);
                return privileges.ToList();
            }
        }

        public static string login(string email, string password)
        {
            if (AuthController.validatePassword(email, password))
            {
                Users usr;
                using (var dbContext = new WashingtonRedskinsContext())
                {
                    usr = dbContext.Users.Where(u => u.Email == email).First();
                }
                return AuthController.generateToken(usr);
            }
            return null;
        }
        public void add()
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbContext.Users.Add(this);
                dbContext.SaveChanges();
            }
        }

        public static Users get(uint id)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                return dbContext.Users.Find(id);
            }
        }

        public static List<Users> list(int pageSize = 50, int skip = 0, uint userGroupId = 0, uint departmentId = 0)
        {
            IQueryable<Users> dbUsers;
            using (var dbContext = new WashingtonRedskinsContext())
            {
                dbUsers = dbContext.Users;

                if (pageSize != 0)
                {
                    dbUsers = dbUsers.Take(pageSize);
                }
                if (skip != 0)
                {
                    dbUsers = dbUsers.Skip(skip);
                }
                if(userGroupId != 0)
                {
                    dbUsers = dbUsers.Where(u => u.UserGroupId == userGroupId);
                }
                if(departmentId != 0)
                {
                    dbUsers = dbUsers.Where(u => u.DepartmentId == departmentId);
                }
            return dbUsers.ToList();
            }
        }

        public static void edit(uint id, Users changes)
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
