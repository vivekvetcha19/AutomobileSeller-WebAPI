using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobileSeller.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceHistoryModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_CarModelId",
                table: "ServiceHistories",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_CustomerId",
                table: "ServiceHistories",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHistories");
        }
    }
}
