using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelafornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorUid",
                table: "Compras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Uid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedorUid",
                table: "Compras",
                column: "FornecedorUid");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Uid",
                table: "Fornecedor",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Fornecedor_FornecedorUid",
                table: "Compras",
                column: "FornecedorUid",
                principalTable: "Fornecedor",
                principalColumn: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Fornecedor_FornecedorUid",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Compras_FornecedorUid",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "FornecedorUid",
                table: "Compras");
        }
    }
}
