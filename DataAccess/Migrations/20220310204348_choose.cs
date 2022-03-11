using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class choose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "chooses");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "chooses");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "chooses");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "chooses");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "chooses",
                newName: "IconURL");

            migrationBuilder.CreateTable(
                name: "chooseLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChooseID = table.Column<int>(type: "int", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chooseLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chooseLanguages_chooses_ChooseID",
                        column: x => x.ChooseID,
                        principalTable: "chooses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chooseLanguages_ChooseID",
                table: "chooseLanguages",
                column: "ChooseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chooseLanguages");

            migrationBuilder.RenameColumn(
                name: "IconURL",
                table: "chooses",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "chooses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "chooses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "chooses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "chooses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
