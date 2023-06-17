using Microsoft.EntityFrameworkCore.Migrations;

namespace Gen06_23EjemploAPI.Migrations
{
    public partial class AgregadoAeropuertoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuertos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    IATA = table.Column<string>(nullable: false),
                    ICAO = table.Column<string>(nullable: false),
                    Latitud = table.Column<string>(nullable: false),
                    Longuitud = table.Column<string>(nullable: false),
                    ZonaHoraria = table.Column<string>(nullable: false),
                    Terminal = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuertos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeropuertos");
        }
    }
}
