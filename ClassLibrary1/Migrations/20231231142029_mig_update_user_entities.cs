using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class mig_update_user_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Content",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Content",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Content",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ContentId",
                table: "Courses",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Content_ContentId",
                table: "Courses",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Content_ContentId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ContentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Content");
        }
    }
}
