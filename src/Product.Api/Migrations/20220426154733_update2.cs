using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Product",
                schema: "ProductApi",
                newName: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProductApi");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "ProductApi");
        }
    }
}
