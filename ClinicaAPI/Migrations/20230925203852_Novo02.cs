using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Novo02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: true),
                    IdFuncAlt = table.Column<int>(type: "integer", nullable: false),
                    DtAlt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Horario = table.Column<string>(type: "text", nullable: false),
                    Sala = table.Column<int>(type: "integer", nullable: false),
                    Unidade = table.Column<int>(type: "integer", nullable: false),
                    Dia = table.Column<DateOnly>(type: "date", nullable: false),
                    Repeticao = table.Column<int>(type: "integer", nullable: false),
                    Subtitulo = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: true),
                    Obs = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SaiSozinho = table.Column<bool>(type: "boolean", nullable: false),
                    RespFinanc = table.Column<int>(type: "integer", nullable: false),
                    DtNascim = table.Column<DateOnly>(type: "date", nullable: false),
                    ClienteDesde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    AreaSession = table.Column<string>(type: "text", nullable: true),
                    Identidade = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    TelFixo = table.Column<string>(type: "text", nullable: true),
                    TelComercial = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    Mae = table.Column<string>(type: "text", nullable: true),
                    MaeRestric = table.Column<bool>(type: "boolean", nullable: false),
                    MaeIdentidade = table.Column<string>(type: "text", nullable: true),
                    MaeCpf = table.Column<string>(type: "text", nullable: true),
                    MaeCelular = table.Column<string>(type: "text", nullable: true),
                    MaeTelFixo = table.Column<string>(type: "text", nullable: true),
                    MaeTelComercial = table.Column<string>(type: "text", nullable: true),
                    MaeEmail = table.Column<string>(type: "text", nullable: false),
                    MaeEndereco = table.Column<string>(type: "text", nullable: false),
                    Pai = table.Column<string>(type: "text", nullable: true),
                    PaiRestric = table.Column<bool>(type: "boolean", nullable: false),
                    PaiIdentidade = table.Column<string>(type: "text", nullable: true),
                    PaiCpf = table.Column<string>(type: "text", nullable: true),
                    PaiCelular = table.Column<string>(type: "text", nullable: true),
                    PaiTelFixo = table.Column<string>(type: "text", nullable: true),
                    PaiTelComercial = table.Column<string>(type: "text", nullable: true),
                    PaiEmail = table.Column<string>(type: "text", nullable: false),
                    PaiEndereco = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPessoa = table.Column<int>(type: "integer", nullable: false),
                    CliOuProf = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    DtInclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonoSalas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Unidade = table.Column<int>(type: "integer", nullable: false),
                    Sala = table.Column<int>(type: "integer", nullable: false),
                    IdProfissional = table.Column<int>(type: "integer", nullable: true),
                    DiaSemana = table.Column<string>(type: "text", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: true),
                    Periodo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonoSalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    AnoLetivo = table.Column<int>(type: "integer", nullable: true),
                    Serie = table.Column<string>(type: "text", nullable: true),
                    Escola = table.Column<string>(type: "text", nullable: true),
                    TelEscola = table.Column<int>(type: "integer", nullable: true),
                    Professor = table.Column<string>(type: "text", nullable: true),
                    Periodo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFuncionario = table.Column<int>(type: "integer", nullable: false),
                    DtConclusao = table.Column<DateOnly>(type: "date", nullable: true),
                    Nivel = table.Column<string>(type: "text", nullable: false),
                    Registro = table.Column<string>(type: "text", nullable: true),
                    Instituicao = table.Column<string>(type: "text", nullable: false),
                    NomeFormacao = table.Column<string>(type: "text", nullable: false),
                    AreasRelacionadas = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Help = table.Column<string>(type: "text", nullable: true),
                    Dir = table.Column<bool>(type: "boolean", nullable: true),
                    Secr = table.Column<bool>(type: "boolean", nullable: true),
                    Coord = table.Column<bool>(type: "boolean", nullable: true),
                    Equipe = table.Column<bool>(type: "boolean", nullable: true),
                    SiMesmo = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdColab = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    DtInsercao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DtNasc = table.Column<DateOnly>(type: "date", nullable: false),
                    RG = table.Column<string>(type: "text", nullable: true),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    TelFixo = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DtAdmis = table.Column<DateOnly>(type: "date", nullable: false),
                    DtDeslig = table.Column<DateOnly>(type: "date", nullable: true),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    AreaSession = table.Column<string>(type: "text", nullable: true),
                    SenhaHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "DonoSalas");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.DropTable(
                name: "Formacaos");

            migrationBuilder.DropTable(
                name: "Perfils");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
