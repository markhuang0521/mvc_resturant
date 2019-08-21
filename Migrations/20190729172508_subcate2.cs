using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class subcate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCateId",
                table: "SubCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CateId",
                table: "categories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubCategories",
                newName: "SubCateId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "CateId");
        }
    }
}
