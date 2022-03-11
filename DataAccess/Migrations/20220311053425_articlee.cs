using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class articlee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleID",
                table: "articleLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "articleLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SEO",
                table: "articleLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_articleLanguages_ArticleID",
                table: "articleLanguages",
                column: "ArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_articleLanguages_articles_ArticleID",
                table: "articleLanguages",
                column: "ArticleID",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articleLanguages_articles_ArticleID",
                table: "articleLanguages");

            migrationBuilder.DropIndex(
                name: "IX_articleLanguages_ArticleID",
                table: "articleLanguages");

            migrationBuilder.DropColumn(
                name: "ArticleID",
                table: "articleLanguages");

            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "articleLanguages");

            migrationBuilder.DropColumn(
                name: "SEO",
                table: "articleLanguages");
        }
    }
}
