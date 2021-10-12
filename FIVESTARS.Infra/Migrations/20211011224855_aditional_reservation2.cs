using Microsoft.EntityFrameworkCore.Migrations;

namespace FIVESTARS.Infra.Migrations
{
    public partial class aditional_reservation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA_INICIO",
                table: "RESERVATION",
                newName: "INITIAL_DATE");

            migrationBuilder.RenameColumn(
                name: "DATA_FIM",
                table: "RESERVATION",
                newName: "FINAL_DATE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INITIAL_DATE",
                table: "RESERVATION",
                newName: "DATA_INICIO");

            migrationBuilder.RenameColumn(
                name: "FINAL_DATE",
                table: "RESERVATION",
                newName: "DATA_FIM");
        }
    }
}
