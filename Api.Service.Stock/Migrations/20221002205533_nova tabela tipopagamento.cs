using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelatipopagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoPagamentoUid",
                table: "Compras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoPagamentos",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamentos", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroNotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desconto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPagamentoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteUid",
                        column: x => x.ClienteUid,
                        principalTable: "Clientes",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_TipoPagamentos_TipoPagamentoUid",
                        column: x => x.TipoPagamentoUid,
                        principalTable: "TipoPagamentos",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_TipoPagamentoUid",
                table: "Compras",
                column: "TipoPagamentoUid");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPagamentos_Uid",
                table: "TipoPagamentos",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteUid",
                table: "Vendas",
                column: "ClienteUid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_TipoPagamentoUid",
                table: "Vendas",
                column: "TipoPagamentoUid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Uid",
                table: "Vendas",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_TipoPagamentos_TipoPagamentoUid",
                table: "Compras",
                column: "TipoPagamentoUid",
                principalTable: "TipoPagamentos",
                principalColumn: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_TipoPagamentos_TipoPagamentoUid",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "TipoPagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Compras_TipoPagamentoUid",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "TipoPagamentoUid",
                table: "Compras");
        }
    }
}
