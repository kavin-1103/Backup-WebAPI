using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class ChangedRoleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d",
                column: "NormalizedName",
                value: "CUSTOMER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4742a2e0-04d2-46ca-925a-bb0439e378b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcba26b2-491b-4aae-a11c-aa631ea6cd47", "AQAAAAIAAYagAAAAENulEPwxj8NV42gejjFXNhNFc8BJGEoQ98aZoxd4ba1LFneiXupXfCtPGulllT1FKw==", "1bb8f7d1-3bb1-4449-830f-f8c186e5f05b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d",
                column: "NormalizedName",
                value: "CUSTOMET");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4742a2e0-04d2-46ca-925a-bb0439e378b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94f19e22-b8cd-404b-88a8-b15295c3b1f4", "AQAAAAIAAYagAAAAEJH8qWJX1g/0SRWG0RWIF8k0Q/6xTqg0cZWg+a2b172OW4sISWcJOGLq2AUojKv1gw==", "70598118-1ee2-4319-a25e-493eeddc9ea7" });
        }
    }
}
