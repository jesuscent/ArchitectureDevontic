using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchitectureDevontic.Database.Migrations
{
    public partial class base2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Pedidos",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Pedidos",
                newName: "OrderDate");
        }
    }
}
