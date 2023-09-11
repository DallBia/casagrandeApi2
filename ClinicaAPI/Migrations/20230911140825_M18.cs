using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class M18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfil2s");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfils");

            migrationBuilder.CreateTable(
                name: "Perfil2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Coord = table.Column<bool>(type: "boolean", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Dir = table.Column<bool>(type: "boolean", nullable: true),
                    Equipe = table.Column<bool>(type: "boolean", nullable: true),
                    Help = table.Column<string>(type: "text", nullable: true),
                    Secr = table.Column<bool>(type: "boolean", nullable: true),
                    SiMesmo = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil2s", x => x.Id);
                });
        }
    }
}
