using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelaitensvendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensVendas",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Quantidade = table.Column<double>(type: "float", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VendaUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendas", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ItensVendas_Produtos_ProdutoUid",
                        column: x => x.ProdutoUid,
                        principalTable: "Produtos",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_ItensVendas_Vendas_VendaUid",
                        column: x => x.VendaUid,
                        principalTable: "Vendas",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_ProdutoUid",
                table: "ItensVendas",
                column: "ProdutoUid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_VendaUid",
                table: "ItensVendas",
                column: "VendaUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVendas");
        }
    }
}
