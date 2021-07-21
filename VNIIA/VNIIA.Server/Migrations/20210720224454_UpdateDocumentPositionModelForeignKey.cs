using Microsoft.EntityFrameworkCore.Migrations;

namespace VNIIA.Server.Migrations
{
    public partial class UpdateDocumentPositionModelForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentPostions_Documents_DocumentForeignKey",
                table: "DocumentPostions");

            migrationBuilder.RenameColumn(
                name: "DocumentForeignKey",
                table: "DocumentPostions",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentPostions_DocumentForeignKey",
                table: "DocumentPostions",
                newName: "IX_DocumentPostions_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentPostions_Documents_DocumentId",
                table: "DocumentPostions",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentPostions_Documents_DocumentId",
                table: "DocumentPostions");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "DocumentPostions",
                newName: "DocumentForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentPostions_DocumentId",
                table: "DocumentPostions",
                newName: "IX_DocumentPostions_DocumentForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentPostions_Documents_DocumentForeignKey",
                table: "DocumentPostions",
                column: "DocumentForeignKey",
                principalTable: "Documents",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
