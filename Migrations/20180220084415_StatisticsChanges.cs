using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class statisticsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registration_summary_month");

            migrationBuilder.DropTable(
                name: "registration_summary_week");

            migrationBuilder.AlterColumn<uint>(
                name: "department_id",
                table: "registrations",
                nullable: true,
                oldClrType: typeof(uint));

            migrationBuilder.AlterColumn<uint>(
                name: "department_id",
                table: "registration_summary",
                nullable: true,
                oldClrType: typeof(uint));

            migrationBuilder.AddColumn<int>(
                name: "year_month",
                table: "registration_summary",
                type: "integer(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year_week",
                table: "registration_summary",
                type: "integer(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_departments_department_id",
                table: "registrations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrations_departments_department_id",
                table: "registrations");

            migrationBuilder.DropColumn(
                name: "year_month",
                table: "registration_summary");

            migrationBuilder.DropColumn(
                name: "year_week",
                table: "registration_summary");

            migrationBuilder.AlterColumn<uint>(
                name: "department_id",
                table: "registrations",
                nullable: false,
                oldClrType: typeof(uint),
                oldNullable: true);

            migrationBuilder.AlterColumn<uint>(
                name: "department_id",
                table: "registration_summary",
                nullable: false,
                oldClrType: typeof(uint),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_departments_department_id",
                table: "registrations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
