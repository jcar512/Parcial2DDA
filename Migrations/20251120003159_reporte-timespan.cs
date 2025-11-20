using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2DDA.Migrations
{
    /// <inheritdoc />
    public partial class reportetimespan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaximaDiferenciaTiempo",
                table: "Reportes",
                newName: "MaximaDiferenciaTiempoString");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MaximaDiferenciaTiempoTimeSpan",
                table: "Reportes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximaDiferenciaTiempoTimeSpan",
                table: "Reportes");

            migrationBuilder.RenameColumn(
                name: "MaximaDiferenciaTiempoString",
                table: "Reportes",
                newName: "MaximaDiferenciaTiempo");
        }
    }
}
