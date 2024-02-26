using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoesPizza.Migrations
{
    public partial class orderdetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MobileNum",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MobileNum",
                table: "OrderDetails");
        }
    }
}
