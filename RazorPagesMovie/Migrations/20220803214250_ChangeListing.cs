using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class ChangeListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Listings",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "4aebf6d1-cc94-4e9e-a8e4-45009be87808", new DateTime(2022, 8, 2, 18, 56, 22, 533, DateTimeKind.Local).AddTicks(3236), "(CRUD) access to audits", null, "Auditor", "AUDITOR" },
                    { "2", "0de73eed-07b1-4287-b623-dd2dc7dd2e16", new DateTime(2022, 8, 2, 18, 56, 22, 534, DateTimeKind.Local).AddTicks(914), "(CRUD) assignment of roles to users and groups", null, "Role Administrator", "ROLE ADMINISTRATOR" },
                    { "3", "3a0c97fd-af99-4096-bdd0-09e278a4bb74", new DateTime(2022, 8, 2, 18, 56, 22, 534, DateTimeKind.Local).AddTicks(955), "(CRUD) Managers items/products", null, "Shopkeeper", "SHOPKEEPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8ecc0744-2402-4fde-8a68-f7fe7a373ac8", "admin@admin.com", false, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBVrFPHCg76cf3VSfiO4zv6AcwYWuyoi0hILua2UZBwuuEy0y42lMfQIHWLqWK+0Gg==", null, false, "067484d9-a3f3-4f1d-ae8a-b27cafa48c10", false, "admin@admin.com" });
        }
    }
}
