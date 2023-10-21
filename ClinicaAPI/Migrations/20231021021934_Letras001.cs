using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Letras001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelFixo",
                table: "Users",
                newName: "telFixo");

            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Users",
                newName: "senhaHash");

            migrationBuilder.RenameColumn(
                name: "RG",
                table: "Users",
                newName: "rg");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Users",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "IdPerfil",
                table: "Users",
                newName: "idPerfil");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Users",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DtNasc",
                table: "Users",
                newName: "dtNasc");

            migrationBuilder.RenameColumn(
                name: "DtDeslig",
                table: "Users",
                newName: "dtDeslig");

            migrationBuilder.RenameColumn(
                name: "DtAdmis",
                table: "Users",
                newName: "dtAdmis");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Users",
                newName: "celular");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Users",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Users",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "AreaSession",
                table: "Users",
                newName: "areaSession");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idFuncAlt = table.Column<int>(type: "integer", nullable: false),
                    nomeInfo = table.Column<string>(type: "text", nullable: false),
                    subtitulo = table.Column<string>(type: "text", nullable: true),
                    dtInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    dtFim = table.Column<DateOnly>(type: "date", nullable: true),
                    tipoInfo = table.Column<string>(type: "text", nullable: false),
                    destinat = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.RenameColumn(
                name: "telFixo",
                table: "Users",
                newName: "TelFixo");

            migrationBuilder.RenameColumn(
                name: "senhaHash",
                table: "Users",
                newName: "SenhaHash");

            migrationBuilder.RenameColumn(
                name: "rg",
                table: "Users",
                newName: "RG");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "idPerfil",
                table: "Users",
                newName: "IdPerfil");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "Users",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dtNasc",
                table: "Users",
                newName: "DtNasc");

            migrationBuilder.RenameColumn(
                name: "dtDeslig",
                table: "Users",
                newName: "DtDeslig");

            migrationBuilder.RenameColumn(
                name: "dtAdmis",
                table: "Users",
                newName: "DtAdmis");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Users",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "celular",
                table: "Users",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "Users",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "areaSession",
                table: "Users",
                newName: "AreaSession");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");
        }
    }
}
