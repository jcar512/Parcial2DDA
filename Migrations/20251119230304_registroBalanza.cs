using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2DDA.Migrations
{
    /// <inheritdoc />
    public partial class registroBalanza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Huella = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngresoRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");
        }
    }
}
