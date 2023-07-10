using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDbForMini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddToCartId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddToCart",
                columns: table => new
                {
                    AddToCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddToCart", x => x.AddToCartId);
                });

            migrationBuilder.CreateTable(
                name: "BookOrder",
                columns: table => new
                {
                    BookOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOrder", x => x.BookOrderId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems");

            migrationBuilder.DropTable(
                name: "AddToCart");

            migrationBuilder.DropTable(
                name: "BookOrder");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_AddToCartId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "AddToCartId",
                table: "FoodItems");
        }
    }
}
