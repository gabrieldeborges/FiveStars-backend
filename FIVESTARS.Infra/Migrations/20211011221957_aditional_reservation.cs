using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIVESTARS.Infra.Migrations
{
    public partial class aditional_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BIRTH_DATE",
                table: "CLIENT",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "CLIENT",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RESERVATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_CLIENT = table.Column<int>(type: "int", nullable: false),
                    ID_BEDROOM = table.Column<int>(type: "int", nullable: false),
                    OBSERVATION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATA_INICIO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_FIM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESERVATION_BEDROOM_ID_BEDROOM",
                        column: x => x.ID_BEDROOM,
                        principalTable: "BEDROOM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVATION_CLIENT_ID_CLIENT",
                        column: x => x.ID_CLIENT,
                        principalTable: "CLIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATION_ID_BEDROOM",
                table: "RESERVATION",
                column: "ID_BEDROOM");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATION_ID_CLIENT",
                table: "RESERVATION",
                column: "ID_CLIENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESERVATION");

            migrationBuilder.DropColumn(
                name: "BIRTH_DATE",
                table: "CLIENT");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "CLIENT");
        }
    }
}
