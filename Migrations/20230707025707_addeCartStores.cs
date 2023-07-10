using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class addeCartStores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_AddToCartId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "AddToCartId",
                table: "FoodItems");

            migrationBuilder.CreateTable(
                name: "CartStores",
                columns: table => new
                {
                    CartStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddToCartId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartStores", x => x.CartStoreId);
                    table.ForeignKey(
                        name: "FK_CartStores_AddToCart_AddToCartId",
                        column: x => x.AddToCartId,
                        principalTable: "AddToCart",
                        principalColumn: "AddToCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartStores_AddToCartId",
                table: "CartStores",
                column: "AddToCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartStores");

            migrationBuilder.AddColumn<int>(
                name: "AddToCartId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_AddToCartId",
                table: "FoodItems",
                column: "AddToCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems",
                column: "AddToCartId",
                principalTable: "AddToCart",
                principalColumn: "AddToCartId");
        }
    }
}
