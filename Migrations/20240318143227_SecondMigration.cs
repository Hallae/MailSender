using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMailSender.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "EmailDto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusMessage",
                table: "EmailDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "EmailDto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "EmailDto");

            migrationBuilder.DropColumn(
                name: "StatusMessage",
                table: "EmailDto");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "EmailDto");
        }
    }
}
