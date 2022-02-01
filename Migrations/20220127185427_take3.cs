using Microsoft.EntityFrameworkCore.Migrations;

namespace bun.Migrations
{
    public partial class take3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionToken_AspNetUsers_UserId",
                table: "SessionToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionToken",
                table: "SessionToken");

            migrationBuilder.RenameTable(
                name: "SessionToken",
                newName: "SessionTokens");

            migrationBuilder.RenameIndex(
                name: "IX_SessionToken_UserId",
                table: "SessionTokens",
                newName: "IX_SessionTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionTokens",
                table: "SessionTokens",
                column: "Jti");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTokens_AspNetUsers_UserId",
                table: "SessionTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionTokens_AspNetUsers_UserId",
                table: "SessionTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionTokens",
                table: "SessionTokens");

            migrationBuilder.RenameTable(
                name: "SessionTokens",
                newName: "SessionToken");

            migrationBuilder.RenameIndex(
                name: "IX_SessionTokens_UserId",
                table: "SessionToken",
                newName: "IX_SessionToken_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionToken",
                table: "SessionToken",
                column: "Jti");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionToken_AspNetUsers_UserId",
                table: "SessionToken",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
