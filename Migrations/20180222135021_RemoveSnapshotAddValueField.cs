using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class RemoveSnapshotAddValueField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "workhours_breaks",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "workhours",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "vacations",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_workhours",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_vacations",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups_privileges",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "statuses",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time",
                table: "registrations_edits",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "registrations",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "privileges",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "departments",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "'0000-00-00 00:00:00'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "workhours_breaks",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "workhours",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "vacations",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_workhours",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users_vacations",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups_privileges",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "usergroups",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "statuses",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time",
                table: "registrations_edits",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "registrations",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "privileges",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "departments",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");
        }
    }
}
