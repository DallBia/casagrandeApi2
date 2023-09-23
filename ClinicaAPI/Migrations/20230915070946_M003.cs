using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class M003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaeCelular",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaeCpf",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaeEmail",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaeEndereco",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaeIdentidade",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaeTelComercial",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaeTelFixo",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaiCelular",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaiCpf",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaiEmail",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaiEndereco",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaiIdentidade",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaiTelComercial",
                table: "Clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaiTelFixo",
                table: "Clientes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeCelular",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeCpf",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeEmail",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeEndereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeIdentidade",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeTelComercial",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MaeTelFixo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiCelular",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiCpf",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiEmail",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiEndereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiIdentidade",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiTelComercial",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaiTelFixo",
                table: "Clientes");
        }
    }
}
