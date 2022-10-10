using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Migrations
{
    public partial class novatabelauserregisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseUserRegisters",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisterStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DbRegisterUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUserRegisters", x => x.Uid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUserRegisters_DbRegisterUid_UserUid",
                table: "CourseUserRegisters",
                columns: new[] { "DbRegisterUid", "UserUid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUserRegisters_UserUid",
                table: "CourseUserRegisters",
                column: "UserUid")
                .Annotation("SqlServer:Include", new[] { "AccessStatus", "RegisterStatus", "CreatedAt", "DbRegisterUid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseUserRegisters");
        }
    }
}
