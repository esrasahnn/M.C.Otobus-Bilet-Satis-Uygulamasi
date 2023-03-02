using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehicleConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleDefinitionId = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleDefinition_VehicleDefinitionId",
                        column: x => x.VehicleDefinitionId,
                        principalTable: "VehicleDefinition",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "PlateNumber", "RegistrationDate", "RegistrationNumber", "VehicleDefinitionId" },
                values: new object[,]
                {
                    { 1, "34TJ0350", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AA658549", 1 },
                    { 2, "34CRN470", new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "AB123478", 2 },
                    { 3, "53OZD47", new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CD854621", 3 },
                    { 4, "21ABC737", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE854746", 4 },
                    { 5, "47ZHR939", new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "EE217634", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleDefinitionId",
                table: "Vehicle",
                column: "VehicleDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
