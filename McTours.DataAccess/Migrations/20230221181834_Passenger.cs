using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class Passenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstimadDuration",
                table: "BusTrip",
                newName: "EstimatedDuration");

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusTripId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    BusTripId1 = table.Column<int>(type: "int", nullable: true),
                    PassengerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_BusTrip_BusTripId",
                        column: x => x.BusTripId,
                        principalTable: "BusTrip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_BusTrip_BusTripId1",
                        column: x => x.BusTripId1,
                        principalTable: "BusTrip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Passenger_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Passenger_PassengerId1",
                        column: x => x.PassengerId1,
                        principalTable: "Passenger",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Gender", "IdentityNumber", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1994, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esra", 0, "12345678912", "Şahin" },
                    { 2, new DateTime(1990, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmut", 0, "35832121631", "Seka" },
                    { 3, new DateTime(1992, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmet", 0, "13895958912", "Aslan" },
                    { 4, new DateTime(1997, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halil", 0, "12389566812", "Ağdaş" }
                });

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2,
                column: "SeatingType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 3,
                column: "SeatingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 6,
                column: "SeatingType",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BusTripId",
                table: "Ticket",
                column: "BusTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BusTripId1",
                table: "Ticket",
                column: "BusTripId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerId",
                table: "Ticket",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerId1",
                table: "Ticket",
                column: "PassengerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.RenameColumn(
                name: "EstimatedDuration",
                table: "BusTrip",
                newName: "EstimadDuration");

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2,
                column: "SeatingType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 3,
                column: "SeatingType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 6,
                column: "SeatingType",
                value: 4);
        }
    }
}
