using System.Collections.Generic;
using WashingtonRedskins.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace WashingtonRedskins.Seed
{
    public static class Seed
    {
        public static void seed()
        {
            var dbcontext = new WashingtonRedskinsContext();
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.Migrate();

            List<Users> myUsers = new List<Users>();
            List<UserGroup> myUserGroups = new List<UserGroup>();
            List<Privileges> myPrivileges = new List<Privileges>();
            List<Departments> myDepartments = new List<Departments>();
            List<Statuses> myStatuses = new List<Statuses>();
            List<Registrations> myRegistrations = new List<Registrations>();

            myStatuses.Add(new Statuses
            {
                Name = "Arbejde"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Barns første sygedag"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Ferie"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Fri"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Pause"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Syg"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Udeblevet"
            });
            myStatuses.Add(new Statuses
            {
                Name = "Ferie/Fridag"
            });

            //myRegistrations.Add(new Registrations
            //{
            //    StatusId = 1,
            //    UserId = 1,
            //    Time = DateTime.Parse("2008, 5, 1, 8, 30, 52")
            //});
            //myRegistrations.Add(new Registrations
            //{
            //    StatusId = 4,
            //    UserId = 1,
            //    Time = DateTime.Parse("2009, 5, 1, 8, 30, 52")
            //});
            //myRegistrations.Add(new Registrations
            //{
            //    StatusId = 2,
            //    UserId = 1,
            //    Time = DateTime.Parse("2009, 6, 1, 8, 30, 52")
            //});
            //myRegistrations.Add(new Registrations
            //{
            //    StatusId = 3,
            //    UserId = 1,
            //    Time = DateTime.Parse("2009, 7, 1, 8, 30, 52")
            //});
            //myRegistrations.Add(new Registrations
            //{
            //    StatusId = 1,
            //    UserId = 1,
            //    Time = DateTime.Parse("2010, 5, 1, 8, 30, 52")
            //});
            //myRegistrations.Add(new Registrations
            //{
            //    StatusId = 4,
            //    UserId = 1,
            //    Time = DateTime.Parse("2010, 5, 1, 16, 30, 52")
            //});

            myUsers.Add(new Users {
                Email = "admin@wrs.dk",
                UserGroupId = 1,
                Address = "Adminvej 1",
                Postcode = "1234",
                CprNr = 1234567890,
                Firstname = "Anders",
                Lastname = "Admin",
                Password = AuthController.hashPassword("password"),
                DepartmentId = 1
            });

            myUsers.Add(new Users
            {
                Email = "ks@wrs.dk",
                UserGroupId = 2,
                Address = "Knudvej 1",
                Postcode = "1235",
                CprNr = 1234567891,
                Firstname = "Knud",
                Lastname = "Kundeservice",
                Password = AuthController.hashPassword("password"),
                DepartmentId = 2
            });
            myUsers.Add(new Users
            {
                Email = "tls@wrs.dk",
                UserGroupId = 2,
                Address = "BOB VEJ1",
                Postcode = "1235",
                CprNr = 231423121,
                Firstname = "TLS",
                Lastname = "Kundeservice",
                Password = AuthController.hashPassword("password"),
                DepartmentId = 2
            });
            myUsers.Add(new Users
            {
                Email = "BO@TeamEasyOn.dk",
                UserGroupId = 2,
                Address = "Tur de France",
                Postcode = "1235",
                CprNr = 1234567801,
                Firstname = "Bobby Olsen",
                Lastname = "Kaptain",
                Password = AuthController.hashPassword("password"),
                DepartmentId = 2
            });


            myUserGroups.Add(new UserGroup
            {
                Name = "Administrator",
            });

            myUserGroups.Add(new UserGroup
            {
                Name = "Kundeservice",
            });

            myDepartments.Add(new Departments
            {
                Name = "IT",
            });
            myDepartments.Add(new Departments
            {
                Name = "Kundeservice",
            });

            myPrivileges.Add(new Privileges() { Name = "users.read" });
            myPrivileges.Add(new Privileges() { Name = "users.write" });
            myPrivileges.Add(new Privileges() { Name = "users.self.read" });
            myPrivileges.Add(new Privileges() { Name = "users.self.write" });

            myPrivileges.Add(new Privileges() { Name = "breaks.read" });
            myPrivileges.Add(new Privileges() { Name = "breaks.self.read" });
            myPrivileges.Add(new Privileges() { Name = "breaks.write" });
            myPrivileges.Add(new Privileges() { Name = "breaks.self.write" });

            myPrivileges.Add(new Privileges() { Name = "vacations.read" });
            myPrivileges.Add(new Privileges() { Name = "vacations.self.read" });
            myPrivileges.Add(new Privileges() { Name = "vacations.write" });
            myPrivileges.Add(new Privileges() { Name = "vacations.self.write" });

            myPrivileges.Add(new Privileges() { Name = "departments.read" });
            myPrivileges.Add(new Privileges() { Name = "departments.self.read" });
            myPrivileges.Add(new Privileges() { Name = "departments.write" });
            myPrivileges.Add(new Privileges() { Name = "departments.self.write" });

            myPrivileges.Add(new Privileges() { Name = "Statuses.read" });
            myPrivileges.Add(new Privileges() { Name = "Statuses.self.read" });
            myPrivileges.Add(new Privileges() { Name = "Statuses.write" });
            myPrivileges.Add(new Privileges() { Name = "Statuses.self.write" });

            myPrivileges.Add(new Privileges() { Name = "usergroups.read" });
            myPrivileges.Add(new Privileges() { Name = "usergroups.self.read" });
            myPrivileges.Add(new Privileges() { Name = "usergroups.write" });
            myPrivileges.Add(new Privileges() { Name = "usergroups.self.write" });

            myPrivileges.Add(new Privileges() { Name = "workhour.read" });
            myPrivileges.Add(new Privileges() { Name = "workhour.self.read" });
            myPrivileges.Add(new Privileges() { Name = "workhour.write" });
            myPrivileges.Add(new Privileges() { Name = "workhour.self.write" });

            myPrivileges.Add(new Privileges() { Name = "registrations.read" });
            myPrivileges.Add(new Privileges() { Name = "registrations.self.read" });
            myPrivileges.Add(new Privileges() { Name = "registrations.write" });
            myPrivileges.Add(new Privileges() { Name = "registrations.self.write" });
            myPrivileges.Add(new Privileges() { Name = "registrations.delete" });

            myPrivileges.Add(new Privileges() { Name = "statistics.read" });
            myPrivileges.Add(new Privileges() { Name = "statistics.self.read" });
            myPrivileges.Add(new Privileges() { Name = "statistics.write" });
            myPrivileges.Add(new Privileges() { Name = "statistics.self.write" });

            using (var dbContext = new WashingtonRedskinsContext())
            {
                foreach (UserGroup ug in myUserGroups)
                {
                    dbContext.Add(ug);
                }

                foreach(Departments d in myDepartments)
                {
                    dbContext.Add(d);
                }
                dbContext.SaveChanges();

                foreach (Users u in myUsers)
                {
                    dbContext.Add(u);
                }
             
                foreach(Privileges p in myPrivileges)
                {
                    dbContext.Add(p);
                    dbContext.UserGroupsPrivileges.Add(new UserGroupsPriviliges() { UserGroupId = 1, Privilege = p, Isallowed = 1});
                }
                foreach(Statuses s in myStatuses)
                {
                    dbContext.Add(s);
                }
                dbContext.SaveChanges();
            }
                var regEdit = new RegistrationsEdits();
                regEdit.Time = DateTime.Now;
            RegistrationsEdits.add(regEdit);
            RegistrationsSeeder.run();
        }
    }
}
