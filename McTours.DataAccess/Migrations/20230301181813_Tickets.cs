using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class Tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "SeatNumber",
                table: "Ticket",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_IdentityNumber",
                table: "Passenger",
                column: "IdentityNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passenger_IdentityNumber",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "SeatNumber",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: 0);
        }
    }
}
