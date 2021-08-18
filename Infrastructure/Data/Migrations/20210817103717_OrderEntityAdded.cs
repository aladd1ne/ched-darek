using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class OrderEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryTime = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuyerEmail = table.Column<string>(type: "TEXT", nullable: true),
                    OrderDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    ShipToAddress_FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    ShipToAddress_LastName = table.Column<string>(type: "TEXT", nullable: true),
                    ShipToAddress_Street = table.Column<string>(type: "TEXT", nullable: true),
                    ShipToAddress_City = table.Column<string>(type: "TEXT", nullable: true),
                    ShipToAddress_State = table.Column<string>(type: "TEXT", nullable: true),
                    ShipToAddress_ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryMethodID = table.Column<int>(type: "INTEGER", nullable: true),
                    SubTotal = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethod_DeliveryMethodID",
                        column: x => x.DeliveryMethodID,
                        principalTable: "DeliveryMethod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
               name: "OrderItems",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("Sqlite:Autoincrement", true),
                   ItemOrdered_ProductItemId = table.Column<int>(nullable: true),
                   ItemOrdered_ProductName = table.Column<string>(nullable: true),
                   ItemOrdered_PictureUrl = table.Column<string>(nullable: true),
                   Price = table.Column<double>(type: "decimal(18,2)", nullable: false),
                   Quantity = table.Column<int>(nullable: false),
                   OrderId = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_OrderItems", x => x.Id);
                   table.ForeignKey(
                       name: "FK_OrderItems_Orders_OrderId",
                       column: x => x.OrderId,
                       principalTable: "Orders",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodID",
                table: "Orders",
                column: "DeliveryMethodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");
        }
    }
}
