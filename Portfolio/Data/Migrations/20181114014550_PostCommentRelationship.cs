using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Data.Migrations
{
    public partial class PostCommentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_CommentsForeignKey",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostForeignKey",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserForeignKey",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorForeignKey",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentsForeignKey",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostForeignKey",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentsForeignKey",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostForeignKey",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AuthorForeignKey",
                table: "Posts",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorForeignKey",
                table: "Posts",
                newName: "IX_Posts_IdentityUserId");

            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                table: "Comments",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserForeignKey",
                table: "Comments",
                newName: "IX_Comments_IdentityUserId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_IdentityUserId",
                table: "Posts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_IdentityUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Posts",
                newName: "AuthorForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_IdentityUserId",
                table: "Posts",
                newName: "IX_Posts_AuthorForeignKey");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Comments",
                newName: "UserForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IdentityUserId",
                table: "Comments",
                newName: "IX_Comments_UserForeignKey");

            migrationBuilder.AddColumn<int>(
                name: "CommentsForeignKey",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostForeignKey",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentsForeignKey",
                table: "Comments",
                column: "CommentsForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostForeignKey",
                table: "Comments",
                column: "PostForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_CommentsForeignKey",
                table: "Comments",
                column: "CommentsForeignKey",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostForeignKey",
                table: "Comments",
                column: "PostForeignKey",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserForeignKey",
                table: "Comments",
                column: "UserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorForeignKey",
                table: "Posts",
                column: "AuthorForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
