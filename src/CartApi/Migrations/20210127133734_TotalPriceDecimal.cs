using Microsoft.EntityFrameworkCore.Migrations;

namespace CartApi.Migrations
{
    public partial class TotalPriceDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Cart",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "Cart",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
