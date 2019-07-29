using Microsoft.EntityFrameworkCore.Migrations;

namespace Property_API.Migrations
{
    public partial class Update005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "UserDefinedFields",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "UserDefinedFields");
        }
    }
}
