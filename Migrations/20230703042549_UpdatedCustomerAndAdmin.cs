using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Reservation_Management_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCustomerAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Step 1: Customers
            migrationBuilder.Sql("ALTER TABLE [Customers] ADD [NewPasswordHash] varbinary(max) NULL");
            migrationBuilder.Sql("ALTER TABLE [Customers] ADD [NewPasswordSalt] varbinary(max) NULL");

            migrationBuilder.Sql("UPDATE [Customers] SET [NewPasswordHash] = CONVERT(varbinary(max), [PasswordHash], 0)");
            migrationBuilder.Sql("UPDATE [Customers] SET [NewPasswordSalt] = CONVERT(varbinary(max), [PasswordSalt], 0)");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "NewPasswordHash",
                table: "Customers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "NewPasswordSalt",
                table: "Customers",
                newName: "PasswordSalt");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Customers",
                type: "varbinary(max)",
                nullable: false);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Customers",
                type: "varbinary(max)",
                nullable: false);

            // Step 2: Admins (similar logic as above)
            migrationBuilder.Sql("ALTER TABLE [Admins] ADD [NewPasswordHash] varbinary(max) NULL");
            migrationBuilder.Sql("ALTER TABLE [Admins] ADD [NewPasswordSalt] varbinary(max) NULL");

            migrationBuilder.Sql("UPDATE [Admins] SET [NewPasswordHash] = CONVERT(varbinary(max), [PasswordHash], 0)");
            migrationBuilder.Sql("UPDATE [Admins] SET [NewPasswordSalt] = CONVERT(varbinary(max), [PasswordSalt], 0)");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "NewPasswordHash",
                table: "Admins",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "NewPasswordSalt",
                table: "Admins",
                newName: "PasswordSalt");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Admins",
                type: "varbinary(max)",
                nullable: false);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Admins",
                type: "varbinary(max)",
                nullable: false);
        }

      
    

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            
        }
    }
}
