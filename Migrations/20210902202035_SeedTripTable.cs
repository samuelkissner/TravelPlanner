using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlanner.Migrations
{
    public partial class SeedTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "ID", "Budget", "DepartureDate", "Description", "Name", "PhotoPath", "ReturnDate" },
                values: new object[] { 1, 5000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim is having a destination wedding in Findland at the end of the year.", "Tim's Wedding", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "ID", "Budget", "DepartureDate", "Description", "Name", "PhotoPath", "ReturnDate" },
                values: new object[] { 2, 600.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attending a halloween-themed costume party at the company branch in Austin.", "Halloween Party", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "ID", "Budget", "DepartureDate", "Description", "Name", "PhotoPath", "ReturnDate" },
                values: new object[] { 3, 2500.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two week, all-inclusive.", "Carribean Cruise", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
