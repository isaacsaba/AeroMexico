using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAeroMexico.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pasajero",
                columns: table => new
                {
                    PasajeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajero", x => x.PasajeroId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "vuelo",
                columns: table => new
                {
                    VueloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoVuelo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vuelo", x => x.VueloId);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VuelosId = table.Column<int>(type: "int", nullable: false),
                    PasajerosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Pasajero_PasajerosId",
                        column: x => x.PasajerosId,
                        principalTable: "Pasajero",
                        principalColumn: "PasajeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_vuelo_VuelosId",
                        column: x => x.VuelosId,
                        principalTable: "vuelo",
                        principalColumn: "VueloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PasajerosId",
                table: "Reserva",
                column: "PasajerosId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VuelosId",
                table: "Reserva",
                column: "VuelosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Pasajero");

            migrationBuilder.DropTable(
                name: "vuelo");
        }
    }
}
