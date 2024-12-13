using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ruben_Booking.API.Migrations
{
    /// <inheritdoc />
    public partial class RubenDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Participants = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCredential = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCredential = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxSeats = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInService = table.Column<bool>(type: "bit", nullable: false),
                    HasProjector = table.Column<bool>(type: "bit", nullable: false),
                    HasWhiteBoard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Consultants",
                columns: new[] { "Id", "Email", "Password", "Salt", "UserCredential" },
                values: new object[,]
                {
                    { 1, "Janne.Claesson@Firman.se", "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "CSKED18372" },
                    { 2, "Jöns.Jönsson@Firman.se", "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "CSAPD18372" },
                    { 3, "Martin.Beck@Firman.se", "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "CSKAE18372" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Password", "PhoneNumber", "Salt", "UserCredential" },
                values: new object[,]
                {
                    { 1, "Hasse.Jansson@Snut.se", "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", "0738239122", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "EOESK20393" },
                    { 2, "Klas.Fransson@Snut.se", "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", "0738115122", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "EAOKE90113" },
                    { 3, "Ruben.Rubensson@Snut.se", "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", "0728239622", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "EKKLE10395" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "HasProjector", "HasWhiteBoard", "IsInService", "MaxSeats", "Name" },
                values: new object[,]
                {
                    { 1, "Konferensrum 1", true, true, true, 8, "Sommarängen" },
                    { 2, "Konferensrum 2", true, false, true, 4, "Höstvinden" },
                    { 3, "Konferensrum 3", false, true, true, 6, "Vinterstugan" },
                    { 4, "Konferensrum 4", true, true, false, 6, "Vårsolen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
