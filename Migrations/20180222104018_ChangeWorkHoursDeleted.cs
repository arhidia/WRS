using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class ChangeWorkHoursDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "start_time",
                table: "workhours",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "end_time",
                table: "workhours",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "time",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "start_time",
                table: "workhours",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "end_time",
                table: "workhours",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
