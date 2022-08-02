using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class UserRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[] { "1", "1966f8cd-f16a-4f1c-956c-5c2db90c61dc", new DateTime(2022, 8, 2, 16, 15, 54, 311, DateTimeKind.Local).AddTicks(7873), "(CRUD) access to audits", null, "Auditor", "AUDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[] { "2", "cd293425-1c95-4848-a0e2-4434d8bac2f2", new DateTime(2022, 8, 2, 16, 15, 54, 313, DateTimeKind.Local).AddTicks(382), "(CRUD) assignment of roles to users and groups", null, "Role Administrator", "ROLE ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[] { "3", "eda4c836-60df-4e66-ab9e-a5da4fb58231", new DateTime(2022, 8, 2, 16, 15, 54, 313, DateTimeKind.Local).AddTicks(424), "(CRUD) Managers items/products", null, "Shopkeeper", "SHOPKEEPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
