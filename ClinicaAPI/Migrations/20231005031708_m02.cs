using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class m02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelEscola",
                table: "Escolas",
                newName: "telEscola");

            migrationBuilder.RenameColumn(
                name: "Serie",
                table: "Escolas",
                newName: "serie");

            migrationBuilder.RenameColumn(
                name: "Professor",
                table: "Escolas",
                newName: "professor");

            migrationBuilder.RenameColumn(
                name: "Periodo",
                table: "Escolas",
                newName: "periodo");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Escolas",
                newName: "idCliente");

            migrationBuilder.RenameColumn(
                name: "Escola",
                table: "Escolas",
                newName: "escola");

            migrationBuilder.RenameColumn(
                name: "AnoLetivo",
                table: "Escolas",
                newName: "anoLetivo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Escolas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Unidade",
                table: "DonoSalas",
                newName: "unidade");

            migrationBuilder.RenameColumn(
                name: "Sala",
                table: "DonoSalas",
                newName: "sala");

            migrationBuilder.RenameColumn(
                name: "Periodo",
                table: "DonoSalas",
                newName: "periodo");

            migrationBuilder.RenameColumn(
                name: "IdProfissional",
                table: "DonoSalas",
                newName: "idProfissional");

            migrationBuilder.RenameColumn(
                name: "DiaSemana",
                table: "DonoSalas",
                newName: "diaSemana");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "DonoSalas",
                newName: "dataInicio");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "DonoSalas",
                newName: "dataFim");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DonoSalas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Documentos",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "Documentos",
                newName: "idPessoa");

            migrationBuilder.RenameColumn(
                name: "DtInclusao",
                table: "Documentos",
                newName: "dtInclusao");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Documentos",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "CliOuProf",
                table: "Documentos",
                newName: "cliOuProf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Documentos",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telEscola",
                table: "Escolas",
                newName: "TelEscola");

            migrationBuilder.RenameColumn(
                name: "serie",
                table: "Escolas",
                newName: "Serie");

            migrationBuilder.RenameColumn(
                name: "professor",
                table: "Escolas",
                newName: "Professor");

            migrationBuilder.RenameColumn(
                name: "periodo",
                table: "Escolas",
                newName: "Periodo");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Escolas",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "escola",
                table: "Escolas",
                newName: "Escola");

            migrationBuilder.RenameColumn(
                name: "anoLetivo",
                table: "Escolas",
                newName: "AnoLetivo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Escolas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "unidade",
                table: "DonoSalas",
                newName: "Unidade");

            migrationBuilder.RenameColumn(
                name: "sala",
                table: "DonoSalas",
                newName: "Sala");

            migrationBuilder.RenameColumn(
                name: "periodo",
                table: "DonoSalas",
                newName: "Periodo");

            migrationBuilder.RenameColumn(
                name: "idProfissional",
                table: "DonoSalas",
                newName: "IdProfissional");

            migrationBuilder.RenameColumn(
                name: "diaSemana",
                table: "DonoSalas",
                newName: "DiaSemana");

            migrationBuilder.RenameColumn(
                name: "dataInicio",
                table: "DonoSalas",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "dataFim",
                table: "DonoSalas",
                newName: "DataFim");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DonoSalas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Documentos",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "idPessoa",
                table: "Documentos",
                newName: "IdPessoa");

            migrationBuilder.RenameColumn(
                name: "dtInclusao",
                table: "Documentos",
                newName: "DtInclusao");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Documentos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "cliOuProf",
                table: "Documentos",
                newName: "CliOuProf");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Documentos",
                newName: "Id");
        }
    }
}
