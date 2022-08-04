using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDbMigration.Migrations
{
    public partial class Migrationv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Module",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NegativeMarking",
                table: "Module",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Module",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Timed",
                table: "Module",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "NegativeMarking",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "Timed",
                table: "Module");
        }
    }
}
