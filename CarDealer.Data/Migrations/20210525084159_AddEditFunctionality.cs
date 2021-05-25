using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Data.Migrations
{
    public partial class AddEditFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SuplierId",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "SuplierId",
                table: "Parts",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_SuplierId",
                table: "Parts",
                newName: "IX_Parts_SupplierId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Parts",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SupplierId",
                table: "Parts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SupplierId",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Parts",
                newName: "SuplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_SupplierId",
                table: "Parts",
                newName: "IX_Parts_SuplierId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Parts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SuplierId",
                table: "Parts",
                column: "SuplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
