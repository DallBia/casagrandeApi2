using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class M12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlteraAgenda",
                table: "Perfils");

            migrationBuilder.DropColumn(
                name: "AlteraCadOutros",
                table: "Perfils");

            migrationBuilder.DropColumn(
                name: "AlteraCadProprio",
                table: "Perfils");

            migrationBuilder.DropColumn(
                name: "AlteraPerfil",
                table: "Perfils");

            migrationBuilder.RenameColumn(
                name: "ProntClin",
                table: "Perfils",
                newName: "SiMesmo");

            migrationBuilder.RenameColumn(
                name: "ProntAdm",
                table: "Perfils",
                newName: "Secr");

            migrationBuilder.RenameColumn(
                name: "CtrFinanceiro",
                table: "Perfils",
                newName: "Equipe");

            migrationBuilder.RenameColumn(
                name: "CadastraProfiss",
                table: "Perfils",
                newName: "Dir");

            migrationBuilder.RenameColumn(
                name: "CadastraCliente",
                table: "Perfils",
                newName: "Coord");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Perfils",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Perfils");

            migrationBuilder.RenameColumn(
                name: "SiMesmo",
                table: "Perfils",
                newName: "ProntClin");

            migrationBuilder.RenameColumn(
                name: "Secr",
                table: "Perfils",
                newName: "ProntAdm");

            migrationBuilder.RenameColumn(
                name: "Equipe",
                table: "Perfils",
                newName: "CtrFinanceiro");

            migrationBuilder.RenameColumn(
                name: "Dir",
                table: "Perfils",
                newName: "CadastraProfiss");

            migrationBuilder.RenameColumn(
                name: "Coord",
                table: "Perfils",
                newName: "CadastraCliente");

            migrationBuilder.AddColumn<bool>(
                name: "AlteraAgenda",
                table: "Perfils",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteraCadOutros",
                table: "Perfils",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteraCadProprio",
                table: "Perfils",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlteraPerfil",
                table: "Perfils",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
