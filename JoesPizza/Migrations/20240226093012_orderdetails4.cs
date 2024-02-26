using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoesPizza.Migrations
{
    public partial class orderdetails4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "iteamImage",
                table: "OrderDetails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "iteamImage",
                table: "OrderDetails");
        }
    }
}
