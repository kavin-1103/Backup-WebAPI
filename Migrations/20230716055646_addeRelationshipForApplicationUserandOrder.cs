using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class addeRelationshipForApplicationUserandOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da73a21d-04ba-41cf-8cdd-7133e5cf4471", "AQAAAAIAAYagAAAAEH05P0dg5vjWhgMoBMshM4LFVSxFaSznYeDAQLKWpSXH1zvSjLrFpkikmbQTDnpwMg==", "d531cd63-086d-4226-b26e-bbaf1241172a" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a823b0b-08be-47fa-8f62-60c788de6a3b", "AQAAAAIAAYagAAAAEIDLZlc7aUPRG9M/cujI58F8yrT8igkIg22oE7+sADEzAO/f2W7lx/WdkbdbeZh/Vw==", "96397060-78f2-405e-91f8-076d122bbde4" });
        }
    }
}
