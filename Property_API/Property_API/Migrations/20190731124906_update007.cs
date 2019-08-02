using Microsoft.EntityFrameworkCore.Migrations;

namespace Property_API.Migrations
{
    public partial class update007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "PropertyImages",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "PropertyImages",
                newName: "ImagePath");
        }
    }
}
