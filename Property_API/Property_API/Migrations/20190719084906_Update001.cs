using Microsoft.EntityFrameworkCore.Migrations;

namespace Property_API.Migrations
{
    public partial class Update001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlType",
                table: "UserDefinedFields");

            migrationBuilder.DropColumn(
                name: "FieldType",
                table: "UserDefinedFields");

            migrationBuilder.DropColumn(
                name: "ListItems",
                table: "UserDefinedFields");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PropertyUserFields",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PropertyUserFields");

            migrationBuilder.AddColumn<string>(
                name: "ControlType",
                table: "UserDefinedFields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                table: "UserDefinedFields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListItems",
                table: "UserDefinedFields",
                nullable: true);
        }
    }
}
