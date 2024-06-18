using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "228c4215-5203-4001-b61e-4f20c4afe0eb", null, "Guest", "GUEST" },
                    { "6249eb0d-5de4-4a94-b63b-330128c7e1f3", null, "User", "USER" },
                    { "90f71d0e-53b8-4d8d-8c2d-f17269d94197", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "228c4215-5203-4001-b61e-4f20c4afe0eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6249eb0d-5de4-4a94-b63b-330128c7e1f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90f71d0e-53b8-4d8d-8c2d-f17269d94197");
        }
    }
}
