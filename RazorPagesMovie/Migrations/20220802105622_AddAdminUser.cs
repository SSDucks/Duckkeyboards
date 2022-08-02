using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "4aebf6d1-cc94-4e9e-a8e4-45009be87808", new DateTime(2022, 8, 2, 18, 56, 22, 533, DateTimeKind.Local).AddTicks(3236) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "0de73eed-07b1-4287-b623-dd2dc7dd2e16", new DateTime(2022, 8, 2, 18, 56, 22, 534, DateTimeKind.Local).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "3a0c97fd-af99-4096-bdd0-09e278a4bb74", new DateTime(2022, 8, 2, 18, 56, 22, 534, DateTimeKind.Local).AddTicks(955) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8ecc0744-2402-4fde-8a68-f7fe7a373ac8", "admin@admin.com", false, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBVrFPHCg76cf3VSfiO4zv6AcwYWuyoi0hILua2UZBwuuEy0y42lMfQIHWLqWK+0Gg==", null, false, "067484d9-a3f3-4f1d-ae8a-b27cafa48c10", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "1966f8cd-f16a-4f1c-956c-5c2db90c61dc", new DateTime(2022, 8, 2, 16, 15, 54, 311, DateTimeKind.Local).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "cd293425-1c95-4848-a0e2-4434d8bac2f2", new DateTime(2022, 8, 2, 16, 15, 54, 313, DateTimeKind.Local).AddTicks(382) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "eda4c836-60df-4e66-ab9e-a5da4fb58231", new DateTime(2022, 8, 2, 16, 15, 54, 313, DateTimeKind.Local).AddTicks(424) });
        }
    }
}
