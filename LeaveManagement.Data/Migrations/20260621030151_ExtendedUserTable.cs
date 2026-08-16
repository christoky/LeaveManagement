using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a613f95c-78e4-4586-9482-b1581188b897", new DateOnly(1983, 5, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEB51PvyrvaBjsZvPhoYmtjx2zJ8+8hxljRqmMSNFn1qiAgOruw1/Fg0Ice3bYqETHw==", "0fee3cf1-839d-45f4-91cb-02e1b5bf0633" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d8ec55d-f52f-4535-bc0e-a9df6e7e0abe", "AQAAAAIAAYagAAAAEIs+5qhCAKMiDTj2DA8OIXJhjtkc+rjTbd6oFQXnnESV/w7K2IvTX8Ywq0Dx+vtu5g==", "285859ab-f750-4a4c-afc3-2623cc37f4b0" });
        }
    }
}
