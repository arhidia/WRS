using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Migrations
{
    public partial class EditStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_work",
                table: "statuses");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<sbyte>(
                name: "is_work",
                table: "statuses",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)0);
        }
    }
}
