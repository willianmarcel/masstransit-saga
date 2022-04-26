using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerApi.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "CustomerApi",
                newName: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerApi");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "CustomerApi");
        }
    }
}
