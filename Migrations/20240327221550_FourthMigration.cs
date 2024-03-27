using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMailSender.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusMessage",
                table: "EmailDto");

            migrationBuilder.AlterColumn<int>(
                name: "StatusCode",
                table: "EmailDto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusCode",
                table: "EmailDto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusMessage",
                table: "EmailDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
