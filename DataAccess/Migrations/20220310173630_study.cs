using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class study : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "studyLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SEO",
                table: "studyLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudyID",
                table: "studyLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_studyLanguages_StudyID",
                table: "studyLanguages",
                column: "StudyID");

            migrationBuilder.AddForeignKey(
                name: "FK_studyLanguages_study_StudyID",
                table: "studyLanguages",
                column: "StudyID",
                principalTable: "study",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studyLanguages_study_StudyID",
                table: "studyLanguages");

            migrationBuilder.DropIndex(
                name: "IX_studyLanguages_StudyID",
                table: "studyLanguages");

            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "studyLanguages");

            migrationBuilder.DropColumn(
                name: "SEO",
                table: "studyLanguages");

            migrationBuilder.DropColumn(
                name: "StudyID",
                table: "studyLanguages");
        }
    }
}
