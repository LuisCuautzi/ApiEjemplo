using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gen06_23EjemploAPI.Migrations
{
    public partial class AgregadoAvionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumRegistro = table.Column<string>(maxLength: 10, nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    CodigoModelo = table.Column<string>(nullable: false),
                    Capacidad = table.Column<int>(nullable: false),
                    FechaPrimerVuelo = table.Column<DateTime>(nullable: false),
                    NumMotores = table.Column<int>(nullable: false),
                    Antiguedad = table.Column<int>(nullable: false),
                    Estatus = table.Column<int>(nullable: false),
                    AerolineaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviones_Aerolineas_AerolineaID",
                        column: x => x.AerolineaID,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aviones_AerolineaID",
                table: "Aviones",
                column: "AerolineaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aviones");
        }
    }
}
