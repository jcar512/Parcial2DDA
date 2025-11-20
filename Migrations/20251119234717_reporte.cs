using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2DDA.Migrations
{
    /// <inheritdoc />
    public partial class reporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMedicionesRealizadas = table.Column<int>(type: "int", nullable: false),
                    MaximaDiferenciaPeso = table.Column<double>(type: "float", nullable: false),
                    MaximaDiferenciaTiempo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reportes");
        }
    }
}
