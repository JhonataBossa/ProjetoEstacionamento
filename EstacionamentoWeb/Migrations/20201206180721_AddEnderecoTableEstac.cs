using Microsoft.EntityFrameworkCore.Migrations;

namespace EstacionamentoWeb.Migrations
{
    public partial class AddEnderecoTableEstac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Estacionamento");
        }
    }
}
