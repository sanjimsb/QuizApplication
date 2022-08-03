using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDbMigration.Migrations
{
    public partial class migrationv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Quiz",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Quiz");
        }
    }
}
