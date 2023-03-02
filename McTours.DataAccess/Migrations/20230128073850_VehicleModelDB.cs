using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehicleModelDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    VehicleMakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehicleMake_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMake",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    SeatingType = table.Column<int>(type: "int", nullable: false),
                    LineCount = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Utilities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDefinition_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "Man" },
                    { 3, "Neoplan" },
                    { 4, "Setra" },
                    { 5, "Isuzu" },
                    { 6, "Temsa" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 1, "Travego", 1 },
                    { 2, "Tourismo", 1 },
                    { 3, "Novociti", 5 },
                    { 4, "Fortuna", 2 },
                    { 5, "Lions", 2 },
                    { 6, "Cityliner", 3 },
                    { 7, "Tourliner", 3 },
                    { 8, "S Serisi", 4 },
                    { 9, "Maraton", 6 },
                    { 10, "Safir", 6 }
                });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "FuelType", "LineCount", "SeatingType", "Utilities", "VehicleModelId", "Year" },
                values: new object[,]
                {
                    { 1, 1, 20, 2, 4, 1, (short)2023 },
                    { 2, 3, 32, 4, 10, 2, (short)2021 },
                    { 3, 1, 18, 3, 1, 3, (short)2020 },
                    { 4, 2, 36, 1, 2, 4, (short)2019 },
                    { 5, 2, 20, 2, 9, 5, (short)2022 },
                    { 6, 3, 24, 4, 6, 6, (short)2021 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDefinition_VehicleModelId",
                table: "VehicleDefinition",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleMakeId",
                table: "VehicleModel",
                column: "VehicleMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDefinition");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleMake");
        }
    }
}
