using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlocityClothingStore.Server.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Partywear" },
                    { 2, "Bridal" },
                    { 3, "Unstitched" },
                    { 4, "Casual" },
                    { 5, "Pret" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "Amber2234@gmail.com", "Amber Smith" },
                    { 2, "SB455@gmail.com", "Sonia Bachchan" },
                    { 3, "MdK@gmail.com", "Madiha Kaur" },
                    { 4, "SadafA@gmail.com", "Sadaf Aslam" },
                    { 5, "kk@gmail.com", "Floria K" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CustomerId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 4 },
                    { 3, 3 },
                    { 4, 2 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, 1, "'Mehendi ki Raat' Ready To Wear Three Piece Luxury Formal Women Suit with hand embroidery on apple green, handcrafted with complementing blue and magenta appliqué, kora, dabka and resham work.", "MEHENDI KI RAAT", 130.0, "M" },
                    { 2, 2, "The most regal and traditional front open kalidaar in a deep crimson, embellished heavily with zardoze and resham. This kalidar is paired with a matching flary banarsi lehenga.  ", "JAHAN ARA", 239.99000000000001, "M" },
                    { 3, 3, "Zehrin is a modern straight cut in pink with heavy thread embroidery on neck and sleeves. The sleeves are finished with cutwork and hand crafted tassels.", "ZEHRIN (THREE PIECE)", 77.0, "S" },
                    { 4, 4, "Loose kurta with embroidery on shoulder, tassel dori on neckline and frill sleeves. ", "SANORITA", 50.0, "M" },
                    { 5, 5, "katan zari lining embroidered shirt with adda work\r\nKatan zari dupatta with lace Jamawar tehra trouser ", "MALHAAR", 149.99000000000001, "M" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, 5, 1, 2, "S" },
                    { 2, 4, 2, 4, "M" },
                    { 3, 3, 3, 4, "L" },
                    { 4, 2, 4, 8, "S" },
                    { 5, 1, 5, 10, "M" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "CustomerId", "DateOfTransaction", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(580), 5, 2 },
                    { 2, 2, new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(615), 4, 4 },
                    { 3, 3, new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(616), 3, 6 },
                    { 4, 4, new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(618), 2, 8 },
                    { 5, 5, new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(620), 1, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
