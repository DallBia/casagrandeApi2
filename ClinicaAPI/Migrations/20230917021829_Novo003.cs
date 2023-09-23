using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Novo003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clinico",
                table: "Prontuarios");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Prontuarios",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Prontuarios");

            migrationBuilder.AddColumn<bool>(
                name: "Clinico",
                table: "Prontuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
