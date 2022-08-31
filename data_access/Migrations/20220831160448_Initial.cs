using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxPassengers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    CredentialsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.CredentialsId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArrivalCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Passengers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Passengers",
                        principalColumn: "CredentialsId");
                });

            migrationBuilder.CreateTable(
                name: "ClientFlight",
                columns: table => new
                {
                    ClientsCredentialsId = table.Column<int>(type: "int", nullable: false),
                    FlightsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlight", x => new { x.ClientsCredentialsId, x.FlightsNumber });
                    table.ForeignKey(
                        name: "FK_ClientFlight_Flights_FlightsNumber",
                        column: x => x.FlightsNumber,
                        principalTable: "Flights",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                        column: x => x.ClientsCredentialsId,
                        principalTable: "Passengers",
                        principalColumn: "CredentialsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxPassengers", "Model" },
                values: new object[] { 1, 1200, "Boeing 765" });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "ClientId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, null, "fly3434", "Qwer23" },
                    { 2, null, "man66", "Blabla3" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "CredentialsId", "Birthdate", "Email", "FirstName" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "super55@ukr.net", "Viktor" },
                    { 2, new DateTime(1995, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "gigigi@gmail.com", "Olga" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime", "Rating" },
                values: new object[] { 1, 1, "Lviv", new DateTime(2022, 8, 25, 18, 25, 0, 0, DateTimeKind.Unspecified), "Kyiv", new DateTime(2022, 8, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime", "Rating" },
                values: new object[] { 2, 1, "Lviv", new DateTime(2022, 9, 13, 5, 0, 0, 0, DateTimeKind.Unspecified), "Warsaw", new DateTime(2022, 9, 12, 15, 30, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_ClientId",
                table: "Credentials",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Airplanes");
        }
    }
}
