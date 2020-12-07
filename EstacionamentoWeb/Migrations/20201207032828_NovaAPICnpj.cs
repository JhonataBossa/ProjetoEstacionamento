using Microsoft.EntityFrameworkCore.Migrations;

namespace EstacionamentoWeb.Migrations
{
    public partial class NovaAPICnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Estacionamento");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Usuario",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Usuario",
                newName: "Situacao");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Usuario",
                newName: "Fantasia");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Usuario",
                newName: "Capital_social");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Usuario",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Estacionamento");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Usuario",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "Situacao",
                table: "Usuario",
                newName: "Localidade");

            migrationBuilder.RenameColumn(
                name: "Fantasia",
                table: "Usuario",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Capital_social",
                table: "Usuario",
                newName: "Bairro");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
