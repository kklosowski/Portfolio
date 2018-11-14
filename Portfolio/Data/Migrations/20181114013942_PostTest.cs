using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Data.Migrations
{
    public partial class PostTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "AuthorForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AuthorForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorForeignKey",
                table: "Posts",
                column: "AuthorForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorForeignKey",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorForeignKey",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorForeignKey",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
