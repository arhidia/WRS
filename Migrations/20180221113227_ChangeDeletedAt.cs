using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class ChangeDeletedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_workhours",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_vacations",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups_privileges",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "statuses",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "registrations",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "registration_summary",
                type: "datetime",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_workhours",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_vacations",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups_privileges",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "statuses",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "registrations",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "registration_summary",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");
        }
    }
}
