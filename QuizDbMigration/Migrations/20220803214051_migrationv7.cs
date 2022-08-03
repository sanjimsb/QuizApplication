using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDbMigration.Migrations
{
    public partial class migrationv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleName",
                table: "Quiz");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Quiz",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Quiz");

            migrationBuilder.AddColumn<string>(
                name: "ModuleName",
                table: "Quiz",
                type: "TEXT",
                nullable: true);
        }
    }
}
