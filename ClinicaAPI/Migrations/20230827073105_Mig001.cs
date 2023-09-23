using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Mig001 : Migration
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
                    Mae = table.Column<string>(type: "text", nullable: true),
                    Pai = table.Column<string>(type: "text", nullable: true),
                    DtInclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaeRestric = table.Column<bool>(type: "boolean", nullable: false),
                    PaiRestric = table.Column<bool>(type: "boolean", nullable: false),
                    SaiSozinho = table.Column<bool>(type: "boolean", nullable: false),
                    RespFinanc = table.Column<int>(type: "integer", nullable: false),
                    Identidade = table.Column<int>(type: "integer", nullable: true),
                    DtNascim = table.Column<DateOnly>(type: "date", nullable: false),
                    Celular = table.Column<int>(type: "integer", nullable: true),
                    TelFixo = table.Column<int>(type: "integer", nullable: true),
                    TelComercial = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    ClienteDesde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    AreaSession = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DtNasc = table.Column<DateOnly>(type: "date", nullable: false),
                    RG = table.Column<int>(type: "integer", nullable: false),
                    CPF = table.Column<int>(type: "integer", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    TelFixo = table.Column<int>(type: "integer", nullable: true),
                    Celular = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DtAdmis = table.Column<DateOnly>(type: "date", nullable: false),
                    DtDeslig = table.Column<DateOnly>(type: "date", nullable: false),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    AreaSession = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradors", x => x.Id);
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
                    ProntAdm = table.Column<bool>(type: "boolean", nullable: false),
                    ProntClin = table.Column<bool>(type: "boolean", nullable: false),
                    AlteraAgenda = table.Column<bool>(type: "boolean", nullable: false),
                    CtrFinanceiro = table.Column<bool>(type: "boolean", nullable: false),
                    CadastraCliente = table.Column<bool>(type: "boolean", nullable: false),
                    AlteraPerfil = table.Column<bool>(type: "boolean", nullable: false),
                    AlteraCadProprio = table.Column<bool>(type: "boolean", nullable: false),
                    AlteraCadOutros = table.Column<bool>(type: "boolean", nullable: false),
                    CadastraProfiss = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.Id);
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
                name: "Colaboradors");

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
        }
    }
}
