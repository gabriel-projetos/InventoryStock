using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelafornecedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Fornecedor_FornecedorUid",
                table: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedor_Uid",
                table: "Fornecedores",
                newName: "IX_Fornecedores_Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Fornecedores_FornecedorUid",
                table: "Compras",
                column: "FornecedorUid",
                principalTable: "Fornecedores",
                principalColumn: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Fornecedores_FornecedorUid",
                table: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_Uid",
                table: "Fornecedor",
                newName: "IX_Fornecedor_Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Fornecedor_FornecedorUid",
                table: "Compras",
                column: "FornecedorUid",
                principalTable: "Fornecedor",
                principalColumn: "Uid");
        }
    }
}
