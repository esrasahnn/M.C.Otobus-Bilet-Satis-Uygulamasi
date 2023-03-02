using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehicleDefinitionEnumSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 1,
                column: "Utilities",
                value: 9);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2,
                column: "Utilities",
                value: 6);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 5,
                column: "Utilities",
                value: 5);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 6,
                column: "Utilities",
                value: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 1,
                column: "Utilities",
                value: 4);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2,
                column: "Utilities",
                value: 10);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 5,
                column: "Utilities",
                value: 9);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 6,
                column: "Utilities",
                value: 6);
        }
    }
}
