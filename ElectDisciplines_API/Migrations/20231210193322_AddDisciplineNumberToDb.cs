using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectDisciplinesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDisciplineNumberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplineNumbers",
                columns: table => new
                {
                    DisciplineNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineNumbers", x => x.DisciplineNo);
                });

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 21, 33, 22, 764, DateTimeKind.Local).AddTicks(8064));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineNumbers");

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
    }
}
