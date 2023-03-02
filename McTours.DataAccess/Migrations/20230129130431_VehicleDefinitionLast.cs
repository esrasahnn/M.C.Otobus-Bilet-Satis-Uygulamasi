using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehicleDefinitionLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 1,
                column: "LineCount",
                value: 10);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2,
                column: "LineCount",
                value: 11);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 3,
                column: "LineCount",
                value: 12);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 4,
                column: "LineCount",
                value: 10);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 5,
                column: "LineCount",
                value: 11);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 6,
                column: "LineCount",
                value: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 1,
                column: "LineCount",
                value: 20);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2,
                column: "LineCount",
                value: 32);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 3,
                column: "LineCount",
                value: 18);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 4,
                column: "LineCount",
                value: 36);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 5,
                column: "LineCount",
                value: 20);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 6,
                column: "LineCount",
                value: 24);
        }
    }
}
