using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCompra_Produto_ProdutoUid",
                table: "ItensCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensCompra",
                table: "ItensCompra");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "ItensCompra",
                newName: "ItensCompras");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_Uid",
                table: "Produtos",
                newName: "IX_Produtos_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_Estoque",
                table: "Produtos",
                newName: "IX_Produtos_Estoque");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCompra_Uid",
                table: "ItensCompras",
                newName: "IX_ItensCompras_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCompra_ProdutoUid",
                table: "ItensCompras",
                newName: "IX_ItensCompras_ProdutoUid");

            migrationBuilder.AddColumn<Guid>(
                name: "CompraUid",
                table: "ItensCompras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensCompras",
                table: "ItensCompras",
                column: "Uid");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroNotaFiscal = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Uid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompras_CompraUid",
                table: "ItensCompras",
                column: "CompraUid");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Uid",
                table: "Compras",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCompras_Compras_CompraUid",
                table: "ItensCompras",
                column: "CompraUid",
                principalTable: "Compras",
                principalColumn: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCompras_Produtos_ProdutoUid",
                table: "ItensCompras",
                column: "ProdutoUid",
                principalTable: "Produtos",
                principalColumn: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCompras_Compras_CompraUid",
                table: "ItensCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensCompras_Produtos_ProdutoUid",
                table: "ItensCompras");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensCompras",
                table: "ItensCompras");

            migrationBuilder.DropIndex(
                name: "IX_ItensCompras_CompraUid",
                table: "ItensCompras");

            migrationBuilder.DropColumn(
                name: "CompraUid",
                table: "ItensCompras");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "ItensCompras",
                newName: "ItensCompra");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_Uid",
                table: "Produto",
                newName: "IX_Produto_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_Estoque",
                table: "Produto",
                newName: "IX_Produto_Estoque");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCompras_Uid",
                table: "ItensCompra",
                newName: "IX_ItensCompra_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCompras_ProdutoUid",
                table: "ItensCompra",
                newName: "IX_ItensCompra_ProdutoUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensCompra",
                table: "ItensCompra",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCompra_Produto_ProdutoUid",
                table: "ItensCompra",
                column: "ProdutoUid",
                principalTable: "Produto",
                principalColumn: "Uid");
        }
    }
}
