using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "breaks",
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
                table: "breaks",
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
