using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotivePartsOrdering.Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    GrossValue = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleReferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlternativePart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupersessionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlternativeType = table.Column<int>(type: "int", nullable: true),
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativePart_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartsOrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    OrderReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MandatoryVehicleReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlternateDeliveryAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Address_AlternateDeliveryAddressId",
                        column: x => x.AlternateDeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderContacts_OrderContactId",
                        column: x => x.OrderContactId,
                        principalTable: "OrderContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VehicleReferences_MandatoryVehicleReferenceId",
                        column: x => x.MandatoryVehicleReferenceId,
                        principalTable: "VehicleReferences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AlternativePartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartDetail_AlternativePart_AlternativePartId",
                        column: x => x.AlternativePartId,
                        principalTable: "AlternativePart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartsOrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartsOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitOfSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartsOrderLineStatus = table.Column<int>(type: "int", nullable: false),
                    ListPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsOrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsOrderLines_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsOrderLines_Prices_ListPriceId",
                        column: x => x.ListPriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsOrderLines_Prices_OrderPriceId",
                        column: x => x.OrderPriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsOrderLines_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativePart_PartId",
                table: "AlternativePart",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AlternateDeliveryAddressId",
                table: "Orders",
                column: "AlternateDeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MandatoryVehicleReferenceId",
                table: "Orders",
                column: "MandatoryVehicleReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderContactId",
                table: "Orders",
                column: "OrderContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PartDetail_AlternativePartId",
                table: "PartDetail",
                column: "AlternativePartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrderLines_ListPriceId",
                table: "PartsOrderLines",
                column: "ListPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrderLines_OrderId",
                table: "PartsOrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrderLines_OrderPriceId",
                table: "PartsOrderLines",
                column: "OrderPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrderLines_PartId",
                table: "PartsOrderLines",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrderLines_UnitOfMeasureId",
                table: "PartsOrderLines",
                column: "UnitOfMeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartDetail");

            migrationBuilder.DropTable(
                name: "PartsOrderLines");

            migrationBuilder.DropTable(
                name: "AlternativePart");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "OrderContacts");

            migrationBuilder.DropTable(
                name: "VehicleReferences");
        }
    }
}
