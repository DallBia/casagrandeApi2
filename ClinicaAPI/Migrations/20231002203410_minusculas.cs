using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class minusculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unidade",
                table: "Agendas",
                newName: "unidade");

            migrationBuilder.RenameColumn(
                name: "Subtitulo",
                table: "Agendas",
                newName: "subtitulo");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Agendas",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Sala",
                table: "Agendas",
                newName: "sala");

            migrationBuilder.RenameColumn(
                name: "Repeticao",
                table: "Agendas",
                newName: "repeticao");

            migrationBuilder.RenameColumn(
                name: "Obs",
                table: "Agendas",
                newName: "obs");

            migrationBuilder.RenameColumn(
                name: "IdFuncAlt",
                table: "Agendas",
                newName: "idFuncAlt");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Agendas",
                newName: "idCliente");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Agendas",
                newName: "horario");

            migrationBuilder.RenameColumn(
                name: "Historico",
                table: "Agendas",
                newName: "historico");

            migrationBuilder.RenameColumn(
                name: "DtAlt",
                table: "Agendas",
                newName: "dtAlt");

            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "Agendas",
                newName: "dia");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Agendas",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unidade",
                table: "Agendas",
                newName: "Unidade");

            migrationBuilder.RenameColumn(
                name: "subtitulo",
                table: "Agendas",
                newName: "Subtitulo");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Agendas",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "sala",
                table: "Agendas",
                newName: "Sala");

            migrationBuilder.RenameColumn(
                name: "repeticao",
                table: "Agendas",
                newName: "Repeticao");

            migrationBuilder.RenameColumn(
                name: "obs",
                table: "Agendas",
                newName: "Obs");

            migrationBuilder.RenameColumn(
                name: "idFuncAlt",
                table: "Agendas",
                newName: "IdFuncAlt");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Agendas",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "horario",
                table: "Agendas",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "historico",
                table: "Agendas",
                newName: "Historico");

            migrationBuilder.RenameColumn(
                name: "dtAlt",
                table: "Agendas",
                newName: "DtAlt");

            migrationBuilder.RenameColumn(
                name: "dia",
                table: "Agendas",
                newName: "Dia");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Agendas",
                newName: "Id");
        }
    }
}
