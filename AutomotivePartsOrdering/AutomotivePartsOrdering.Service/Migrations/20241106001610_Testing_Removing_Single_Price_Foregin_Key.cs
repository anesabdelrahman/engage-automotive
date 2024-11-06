using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotivePartsOrdering.Service.Migrations
{
    /// <inheritdoc />
    public partial class Testing_Removing_Single_Price_Foregin_Key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartsOrderLines_Prices_OrderPriceId",
                table: "PartsOrderLines");

            migrationBuilder.DropIndex(
                name: "IX_PartsOrderLines_OrderPriceId",
                table: "PartsOrderLines");

            migrationBuilder.DropColumn(
                name: "OrderPriceId",
                table: "PartsOrderLines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderPriceId",
                table: "PartsOrderLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrderLines_OrderPriceId",
                table: "PartsOrderLines",
                column: "OrderPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartsOrderLines_Prices_OrderPriceId",
                table: "PartsOrderLines",
                column: "OrderPriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
