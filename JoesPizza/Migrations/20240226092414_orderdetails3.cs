using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoesPizza.Migrations
{
    public partial class orderdetails3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Piza_pizzaItemId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_pizzaItemId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "pizzaItemId",
                table: "OrderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pizzaItemId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_pizzaItemId",
                table: "OrderDetails",
                column: "pizzaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Piza_pizzaItemId",
                table: "OrderDetails",
                column: "pizzaItemId",
                principalTable: "Piza",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
