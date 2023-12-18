using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class agenda002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dia",
                table: "Agendas",
                newName: "diaI");

            migrationBuilder.AddColumn<DateOnly>(
                name: "diaF",
                table: "Agendas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaF",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "diaI",
                table: "Agendas",
                newName: "dia");
        }
    }
}
