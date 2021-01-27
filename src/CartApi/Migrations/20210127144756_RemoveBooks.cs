using Microsoft.EntityFrameworkCore.Migrations;

namespace CartApi.Migrations
{
    public partial class RemoveBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Book_BookId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Book_BookId",
                table: "Article",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Book_BookId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Book_BookId",
                table: "Article",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
