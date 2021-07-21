using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VNIIA.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "DocumentPostions",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<int>(type: "int", nullable: false),
                    DocumentForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentPostions", x => x.Number);
                    table.ForeignKey(
                        name: "FK_DocumentPostions_Documents_DocumentForeignKey",
                        column: x => x.DocumentForeignKey,
                        principalTable: "Documents",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentPostions_DocumentForeignKey",
                table: "DocumentPostions",
                column: "DocumentForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentPostions");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
