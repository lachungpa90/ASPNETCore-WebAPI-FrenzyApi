using Microsoft.EntityFrameworkCore.Migrations;

namespace FrenzyAPI.Data.Migrations
{
    public partial class UpdatedEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Users_UserId",
                table: "PurchaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseHistory_UserId",
                table: "PurchaseHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchaseHistory");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "PurchaseHistory",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistory_UsersId",
                table: "PurchaseHistory",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistory_Users_UsersId",
                table: "PurchaseHistory",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Users_UsersId",
                table: "PurchaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseHistory_UsersId",
                table: "PurchaseHistory");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "PurchaseHistory");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PurchaseHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistory_UserId",
                table: "PurchaseHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistory_Users_UserId",
                table: "PurchaseHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
