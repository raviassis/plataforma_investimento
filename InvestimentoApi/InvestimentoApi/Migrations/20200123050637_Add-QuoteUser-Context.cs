using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestimentoApi.Migrations
{
    public partial class AddQuoteUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteUser_Quotes_QuoteId",
                table: "QuoteUser");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteUser_AspNetUsers_UserId",
                table: "QuoteUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteUser",
                table: "QuoteUser");

            migrationBuilder.RenameTable(
                name: "QuoteUser",
                newName: "QuoteUsers");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteUser_UserId",
                table: "QuoteUsers",
                newName: "IX_QuoteUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteUser_QuoteId",
                table: "QuoteUsers",
                newName: "IX_QuoteUsers_QuoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteUsers",
                table: "QuoteUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteUsers_Quotes_QuoteId",
                table: "QuoteUsers",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteUsers_AspNetUsers_UserId",
                table: "QuoteUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteUsers_Quotes_QuoteId",
                table: "QuoteUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteUsers_AspNetUsers_UserId",
                table: "QuoteUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteUsers",
                table: "QuoteUsers");

            migrationBuilder.RenameTable(
                name: "QuoteUsers",
                newName: "QuoteUser");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteUsers_UserId",
                table: "QuoteUser",
                newName: "IX_QuoteUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteUsers_QuoteId",
                table: "QuoteUser",
                newName: "IX_QuoteUser_QuoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteUser",
                table: "QuoteUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteUser_Quotes_QuoteId",
                table: "QuoteUser",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteUser_AspNetUsers_UserId",
                table: "QuoteUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
