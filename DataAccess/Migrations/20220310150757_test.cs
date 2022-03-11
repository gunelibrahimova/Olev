using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubTitle",
                table: "productLanguages",
                newName: "SEO");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "productLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "productLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "productLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productLanguages_ProductID",
                table: "productLanguages",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_productLanguages_products_ProductID",
                table: "productLanguages",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productLanguages_products_ProductID",
                table: "productLanguages");

            migrationBuilder.DropIndex(
                name: "IX_productLanguages_ProductID",
                table: "productLanguages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "productLanguages");

            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "productLanguages");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "productLanguages");

            migrationBuilder.RenameColumn(
                name: "SEO",
                table: "productLanguages",
                newName: "SubTitle");
        }
    }
}
