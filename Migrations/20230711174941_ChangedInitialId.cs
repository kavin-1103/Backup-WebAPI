using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedInitialId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d", "4742a2e0-04d2-46ca-925a-bb0439e378b6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ef50d628-0f80-41e0-bd63-05d384b89b65", "4742a2e0-04d2-46ca-925a-bb0439e378b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef50d628-0f80-41e0-bd63-05d384b89b65");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4742a2e0-04d2-46ca-925a-bb0439e378b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "Admin", "ADMIN" },
                    { "2", "2", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "20cbb376-9547-4bee-886d-fc65e0234b5a", "vignesh123@gmail.com", false, false, null, "vignesh", "VIGNESH123@GMAIL.COM", "VIGNESH", "AQAAAAIAAYagAAAAEEnLPMclx36pdGJv7I8OKeSbk8ILkOFW1nSS50cUtnf/QPI3ypvn7DZS9ZNy264mbQ==", null, false, "0fe63833-a4c7-4728-8db5-4420057a1092", false, "vignesh" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d", "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d", "Customer", "CUSTOMER" },
                    { "ef50d628-0f80-41e0-bd63-05d384b89b65", "ef50d628-0f80-41e0-bd63-05d384b89b65", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4742a2e0-04d2-46ca-925a-bb0439e378b6", 0, "ec921f90-5554-4240-a560-54a6f7c8ba63", "vignesh123@gmail.com", false, false, null, "vignesh", "VIGNESH123@GMAIL.COM", "VIGNESH", "AQAAAAIAAYagAAAAENyin4bfCbK4GTPEUcACRBIouWaoCmdPu8aojbpRvOde5dvqG8EYGF6sS5C8SGW9Jw==", null, false, "0efe9468-3f7f-4360-8af1-9900ff09de90", false, "vignesh" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d", "4742a2e0-04d2-46ca-925a-bb0439e378b6" },
                    { "ef50d628-0f80-41e0-bd63-05d384b89b65", "4742a2e0-04d2-46ca-925a-bb0439e378b6" }
                });
        }
    }
}
