using Microsoft.EntityFrameworkCore.Migrations;

namespace Property_API.Migrations
{
    public partial class update006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                table: "UserDefinedFields",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldType",
                table: "UserDefinedFields");
        }
    }
}
