using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegisteredCustomerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisteredCustomers",
                columns: table => new
                {
                    RegisteredCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredCustomers", x => x.RegisteredCustomerId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53c4baaa-aed0-4698-a1b6-a8f3e5de8f34", "AQAAAAIAAYagAAAAEKihVhq0XdYrUC2oolBW2XB2bmcCS9fBMIUT+m/PuT6QsWG4wi9SgvpYv3iKlMe6OQ==", "62a9d4d3-336c-4808-950e-a206efb2c47a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredCustomers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20cbb376-9547-4bee-886d-fc65e0234b5a", "AQAAAAIAAYagAAAAEEnLPMclx36pdGJv7I8OKeSbk8ILkOFW1nSS50cUtnf/QPI3ypvn7DZS9ZNy264mbQ==", "0fe63833-a4c7-4728-8db5-4420057a1092" });
        }
    }
}
