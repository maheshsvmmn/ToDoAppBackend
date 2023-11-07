using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoetesAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 5, 15, 47, 57, 886, DateTimeKind.Local).AddTicks(4106), "madhav@gmail.com", "user1", "password" },
                    { 2, new DateTime(2023, 11, 5, 15, 47, 57, 886, DateTimeKind.Local).AddTicks(4118), "user1@gmail.com", "user2", "password" },
                    { 3, new DateTime(2023, 11, 5, 15, 47, 57, 886, DateTimeKind.Local).AddTicks(4119), "user@gmail.com", "Madhav", "password" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
