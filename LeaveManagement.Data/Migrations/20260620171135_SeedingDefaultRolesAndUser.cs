using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50670bd3-5090-4c0e-8203-a27defd1fde8", null, "Supervisor", "SUPERVISOR" },
                    { "a4e66228-6894-40e3-8b02-b18e2e0f3300", null, "Employee", "EMPLOYEE" },
                    { "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f", 0, "9d8ec55d-f52f-4535-bc0e-a9df6e7e0abe", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIs+5qhCAKMiDTj2DA8OIXJhjtkc+rjTbd6oFQXnnESV/w7K2IvTX8Ywq0Dx+vtu5g==", null, false, "285859ab-f750-4a4c-afc3-2623cc37f4b0", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50670bd3-5090-4c0e-8203-a27defd1fde8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4e66228-6894-40e3-8b02-b18e2e0f3300");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f");
        }
    }
}
