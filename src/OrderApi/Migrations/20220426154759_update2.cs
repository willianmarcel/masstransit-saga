using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderApi.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Product",
                schema: "OrderApi",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                schema: "OrderApi",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "OrderApi",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "OrderApi",
                newName: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OrderApi");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "OrderApi");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItem",
                newSchema: "OrderApi");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Order",
                newSchema: "OrderApi");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "OrderApi");
        }
    }
}
