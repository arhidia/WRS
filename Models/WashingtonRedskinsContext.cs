using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WashingtonRedskins.Models
{
    public partial class WashingtonRedskinsContext : DbContext
    {
        public virtual DbSet<Breaks> Breaks { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Privileges> Privileges { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<RegistrationSummary> RegistrationSummary { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserGroupsPriviliges> UserGroupsPrivileges { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersVacations> UsersVacations { get; set; }
        public virtual DbSet<UsersWorkHours> UsersWorkHours { get; set; }
        public virtual DbSet<Vacations> Vacations { get; set; }
        public virtual DbSet<WorkHours> WorkHours { get; set; }
        public virtual DbSet<WorkHoursBreaks> WorkHoursBreaks { get; set; }
        public virtual DbSet<RegistrationsEdits> RegistrationsEdits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=root;Database=WashingtonRedskins; Convert Zero Datetime=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breaks>(entity =>
            {
                entity.ToTable("breaks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Privileges>(entity =>
            {
                entity.ToTable("privileges");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Registrations>(entity =>
            {
                entity.ToTable("registrations");

                entity.HasIndex(e => e.StatusId)
                    .HasName("FK_registration_status");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_registration_user");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_registration_department");


                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_registration_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_registration_user");
            });

            modelBuilder.Entity<RegistrationSummary>(entity =>
            {
                entity.ToTable("registration_summary");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("department_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.YearMonth)
                    .HasColumnName("year_month")
                    .HasColumnType("integer(11)");

                entity.Property(e => e.YearWeek)
                    .HasColumnName("year_week")
                    .HasColumnType("integer(11)");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.RegistrationSummary)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registraion_summary_day_department");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.RegistrationSummary)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registraion_summary_day_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RegistrationSummary)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registraion_summary_day_user");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.ToTable("statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RegistrationsEdits>(entity =>
            {
                entity.ToTable("registrations_edits");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("usergroups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserGroupsPriviliges>(entity =>
            {
                entity.ToTable("usergroups_privileges");

                entity.HasIndex(e => e.PrivilegeId)
                    .HasName("FK_usergroup_privilege");

                entity.HasIndex(e => e.UserGroupId)
                    .HasName("FK_privilege_usergroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Isallowed)
                    .HasColumnName("isallowed")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.PrivilegeId).HasColumnName("privilege_id");

                entity.Property(e => e.UserGroupId).HasColumnName("usergroup_id");

                entity.HasOne(d => d.Privilege)
                    .WithMany(p => p.UserGroupsPrivileges)
                    .HasForeignKey(d => d.PrivilegeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_usergroup_privilege");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UserGroupsPrivileges)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_privilege_usergroup");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_users_departments");

                entity.HasIndex(e => e.Password)
                    .HasName("email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.UserGroupId)
                    .HasName("FK_users_usergroups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.CprNr)
                    .HasColumnName("cpr_nr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(50);

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("usergroup_id")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_users_departments");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_users_usergroups");
            });

            modelBuilder.Entity<UsersVacations>(entity =>
            {
                entity.ToTable("users_vacations");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_vacation_user");

                entity.HasIndex(e => e.VacationId)
                    .HasName("FK_user_vacation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VacationId).HasColumnName("vacation_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersVacations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_vacation_user");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.UsersVacations)
                    .HasForeignKey(d => d.VacationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_user_vacation");
            });

            modelBuilder.Entity<UsersWorkHours>(entity =>
            {
                entity.ToTable("users_workhours");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_workhour_user");

                entity.HasIndex(e => e.WorkHourId)
                    .HasName("FK_user_workhour");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WorkHourId).HasColumnName("workhour_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersWorkHours)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_workhour_user");

                entity.HasOne(d => d.WorkHour)
                    .WithMany(p => p.UsersWorkHours)
                    .HasForeignKey(d => d.WorkHourId)
                    .HasConstraintName("FK_user_workhour");
            });

            modelBuilder.Entity<Vacations>(entity =>
            {
                entity.ToTable("vacations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<WorkHours>(entity =>
            {
                entity.ToTable("workhours");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time");
            });

            modelBuilder.Entity<WorkHoursBreaks>(entity =>
            {
                entity.ToTable("workhours_breaks");

                entity.HasIndex(e => e.BreakId)
                    .HasName("FK_workhour_breaks");

                entity.HasIndex(e => e.WorkHourId)
                    .HasName("FK_break_workhours");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BreakId).HasColumnName("break_id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.WorkHourId).HasColumnName("workhour_id");

                entity.HasOne(d => d.Break)
                    .WithMany(p => p.WorkHoursBreaks)
                    .HasForeignKey(d => d.BreakId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_workhour_breaks");

                entity.HasOne(d => d.WorkHour)
                    .WithMany(p => p.WorkHoursBreaks)
                    .HasForeignKey(d => d.WorkHourId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_break_workhours");
            });
            modelBuilder.Entity<Breaks>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<Departments>().HasQueryFilter(p => p.DeletedAt.ToString() == null ||p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<Privileges>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<Registrations>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<Statuses>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<UserGroup>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<Users>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<Vacations>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
            modelBuilder.Entity<WorkHours>().HasQueryFilter(p => p.DeletedAt.ToString() == null || p.DeletedAt.ToString() == "0000-00-00 00:00:00");
        }
    }
}
