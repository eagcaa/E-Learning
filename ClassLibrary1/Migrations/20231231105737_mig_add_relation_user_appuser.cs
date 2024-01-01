using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class mig_add_relation_user_appuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AppUserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Users",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AppUserId",
                table: "Users",
                newName: "IX_Users_AppUserID");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AppUserID",
                table: "Users",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AppUserID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Users",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AppUserID",
                table: "Users",
                newName: "IX_Users_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AppUserId",
                table: "Users",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
