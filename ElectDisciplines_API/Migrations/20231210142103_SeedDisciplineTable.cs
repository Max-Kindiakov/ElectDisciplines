using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectDisciplinesAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDisciplineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 21, 3, 782, DateTimeKind.Local).AddTicks(330));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5055));
        }
    }
}
