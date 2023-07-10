using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class addedRelationshipToAddToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems");

            migrationBuilder.AlterColumn<int>(
                name: "AddToCartId",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems",
                column: "AddToCartId",
                principalTable: "AddToCart",
                principalColumn: "AddToCartId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems");

            migrationBuilder.AlterColumn<int>(
                name: "AddToCartId",
                table: "FoodItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_AddToCart_AddToCartId",
                table: "FoodItems",
                column: "AddToCartId",
                principalTable: "AddToCart",
                principalColumn: "AddToCartId");
        }
    }
}
