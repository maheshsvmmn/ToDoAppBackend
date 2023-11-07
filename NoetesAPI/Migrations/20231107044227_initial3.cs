using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoetesAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 7, 10, 12, 27, 362, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 7, 10, 12, 27, 362, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 7, 10, 12, 27, 362, DateTimeKind.Local).AddTicks(3003));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 7, 8, 57, 33, 887, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 7, 8, 57, 33, 887, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 7, 8, 57, 33, 887, DateTimeKind.Local).AddTicks(8236));
        }
    }
}
