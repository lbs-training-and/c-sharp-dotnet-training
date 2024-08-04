using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureFunction.Challenge.Function.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeliveryAddress_Name = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddress_AddressLineOne = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddress_AddressLineTwo = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddress_City = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddress_PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddress_Country = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress_Name = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress_AddressLineOne = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress_AddressLineTwo = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress_City = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress_PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress_Country = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
