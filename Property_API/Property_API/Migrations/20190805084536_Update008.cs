using Microsoft.EntityFrameworkCore.Migrations;

namespace Property_API.Migrations
{
    public partial class Update008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OperationalCosts",
                table: "Properties",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationalCosts",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Properties");
        }
    }
}
