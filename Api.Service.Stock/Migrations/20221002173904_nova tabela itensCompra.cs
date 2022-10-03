using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelaitensCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensCompra",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Quantidade = table.Column<double>(type: "float", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProdutoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCompra", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ItensCompra_Produto_ProdutoUid",
                        column: x => x.ProdutoUid,
                        principalTable: "Produto",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Estoque",
                table: "Produto",
                column: "Estoque");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_ProdutoUid",
                table: "ItensCompra",
                column: "ProdutoUid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_Uid",
                table: "ItensCompra",
                column: "Uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCompra");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Estoque",
                table: "Produto");
        }
    }
}
