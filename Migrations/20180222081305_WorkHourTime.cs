using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class WorkHourTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "start_time",
                table: "workhours",
                type: "time",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "end_time",
                table: "workhours",
                type: "time",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "start_time",
                table: "workhours",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "end_time",
                table: "workhours",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "time",
                oldNullable: true);
        }
    }
}
