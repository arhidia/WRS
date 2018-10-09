using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "breaks",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breaks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "'0000-00-00 00:00:00'"),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "privileges",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privileges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registration_summary_month",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    department_id = table.Column<uint>(nullable: false),
                    duration = table.Column<uint>(nullable: false),
                    month_year = table.Column<int>(type: "int(11)", nullable: false),
                    status_id = table.Column<uint>(nullable: false),
                    user_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registration_summary_month", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registration_summary_week",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    department_id = table.Column<uint>(nullable: false),
                    duration = table.Column<uint>(nullable: false),
                    status_id = table.Column<uint>(nullable: false),
                    user_id = table.Column<uint>(nullable: false),
                    week_year = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registration_summary_week", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    is_work = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usergroups",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usergroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vacations",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "'0000-00-00 00:00:00'"),
                    end = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    name = table.Column<string>(nullable: true),
                    start = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workhours",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "'0000-00-00 00:00:00'"),
                    end_time = table.Column<int>(type: "int(11)", nullable: true),
                    start_time = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workhours", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usergroups_privileges",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    isallowed = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    privilege_id = table.Column<uint>(nullable: true),
                    usergroup_id = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usergroups_privileges", x => x.id);
                    table.ForeignKey(
                        name: "FK_usergroup_privilege",
                        column: x => x.privilege_id,
                        principalTable: "privileges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_privilege_usergroup",
                        column: x => x.usergroup_id,
                        principalTable: "usergroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    cpr_nr = table.Column<int>(type: "int(11)", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    department_id = table.Column<uint>(nullable: true, defaultValueSql: "'0'"),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    firstname = table.Column<string>(maxLength: 50, nullable: true),
                    lastname = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    postcode = table.Column<string>(maxLength: 50, nullable: true),
                    usergroup_id = table.Column<uint>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_departments",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_users_usergroups",
                        column: x => x.usergroup_id,
                        principalTable: "usergroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workhours_breaks",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    break_id = table.Column<uint>(nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "'0000-00-00 00:00:00'"),
                    workhour_id = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workhours_breaks", x => x.id);
                    table.ForeignKey(
                        name: "FK_workhour_breaks",
                        column: x => x.break_id,
                        principalTable: "breaks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_break_workhours",
                        column: x => x.workhour_id,
                        principalTable: "workhours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "registration_summary",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    department_id = table.Column<uint>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    status_id = table.Column<uint>(nullable: false),
                    user_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registration_summary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registraion_summary_day_department",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_registraion_summary_day_status",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_registraion_summary_day_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    department_id = table.Column<uint>(nullable: false),
                    status_id = table.Column<uint>(nullable: false),
                    time = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    user_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_registrations_departments_DepartmentId",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registration_status",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_registration_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users_vacations",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    user_id = table.Column<uint>(nullable: true),
                    vacation_id = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_vacations", x => x.id);
                    table.ForeignKey(
                        name: "FK_vacation_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_user_vacation",
                        column: x => x.vacation_id,
                        principalTable: "vacations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "users_workhours",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    user_id = table.Column<uint>(nullable: false),
                    workhour_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_workhours", x => x.id);
                    table.ForeignKey(
                        name: "FK_workhour_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_workhour",
                        column: x => x.workhour_id,
                        principalTable: "workhours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "department_id",
                table: "registration_summary",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "status_id",
                table: "registration_summary",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "registration_summary",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "department_id",
                table: "registration_summary_month",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "status_id",
                table: "registration_summary_month",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "registration_summary_month",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "department_id",
                table: "registration_summary_week",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "status_id",
                table: "registration_summary_week",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "registration_summary_week",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "FK_registrations_department",
                table: "registrations",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "FK_registration_status",
                table: "registrations",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_registration_user",
                table: "registrations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "FK_usergroup_privilege",
                table: "usergroups_privileges",
                column: "privilege_id");

            migrationBuilder.CreateIndex(
                name: "FK_privilege_usergroup",
                table: "usergroups_privileges",
                column: "usergroup_id");

            migrationBuilder.CreateIndex(
                name: "FK_users_departments",
                table: "users",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "email_unique",
                table: "users",
                column: "password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_users_usergroups",
                table: "users",
                column: "usergroup_id");

            migrationBuilder.CreateIndex(
                name: "FK_vacation_user",
                table: "users_vacations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_vacation",
                table: "users_vacations",
                column: "vacation_id");

            migrationBuilder.CreateIndex(
                name: "FK_workhour_user",
                table: "users_workhours",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_workhour",
                table: "users_workhours",
                column: "workhour_id");

            migrationBuilder.CreateIndex(
                name: "FK_workhour_breaks",
                table: "workhours_breaks",
                column: "break_id");

            migrationBuilder.CreateIndex(
                name: "FK_break_workhours",
                table: "workhours_breaks",
                column: "workhour_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registration_summary");

            migrationBuilder.DropTable(
                name: "registration_summary_month");

            migrationBuilder.DropTable(
                name: "registration_summary_week");

            migrationBuilder.DropTable(
                name: "registrations");

            migrationBuilder.DropTable(
                name: "usergroups_privileges");

            migrationBuilder.DropTable(
                name: "users_vacations");

            migrationBuilder.DropTable(
                name: "users_workhours");

            migrationBuilder.DropTable(
                name: "workhours_breaks");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "privileges");

            migrationBuilder.DropTable(
                name: "vacations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "breaks");

            migrationBuilder.DropTable(
                name: "workhours");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "usergroups");
        }
    }
}
