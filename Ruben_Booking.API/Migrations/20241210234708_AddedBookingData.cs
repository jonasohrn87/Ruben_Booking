using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ruben_Booking.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "DateFrom", "DateTo", "Participants", "PersonId", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 20, 23, 59, 59, 0, DateTimeKind.Local), "[\"Hasse Jansson\"]", 1, 1 },
                    { 2, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 24, 23, 59, 59, 0, DateTimeKind.Local), "[]", 2, 2 },
                    { 3, new DateTime(2024, 12, 19, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 19, 16, 0, 0, 0, DateTimeKind.Local), "[]", 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
