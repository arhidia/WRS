using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class BreakChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "privileges",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "breaks",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "'0000-00-00 00:00:00'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "privileges",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "breaks",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "'0000-00-00 00:00:00'");
        }
    }
}
