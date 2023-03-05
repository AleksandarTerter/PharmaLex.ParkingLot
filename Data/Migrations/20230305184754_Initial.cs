using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeededSlots = table.Column<byte>(type: "tinyint", nullable: false),
                    DailyChargePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OvernightChargePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivedParkingVehicleEntities",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTimeOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeOfExit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedParkingVehicleEntities", x => new { x.LicensePlate, x.DateTimeOfEntry });
                    table.ForeignKey(
                        name: "FK_ArchivedParkingVehicleEntities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivedParkingVehicleEntities_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParkedVehicles",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<byte>(type: "tinyint", nullable: false),
                    DateTimeOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicles", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_ParkedVehicles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkedVehicles_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedParkingVehicleEntities_CategoryId",
                table: "ArchivedParkingVehicleEntities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedParkingVehicleEntities_DiscountId",
                table: "ArchivedParkingVehicleEntities",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicles_CategoryId",
                table: "ParkedVehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicles_DiscountId",
                table: "ParkedVehicles",
                column: "DiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivedParkingVehicleEntities");

            migrationBuilder.DropTable(
                name: "ParkedVehicles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
