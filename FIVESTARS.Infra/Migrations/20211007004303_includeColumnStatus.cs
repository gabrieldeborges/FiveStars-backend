using Microsoft.EntityFrameworkCore.Migrations;

namespace FIVESTARS.Infra.Migrations
{
    public partial class includeColumnStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "BEDROOM",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "BEDROOM");
        }
    }
}
