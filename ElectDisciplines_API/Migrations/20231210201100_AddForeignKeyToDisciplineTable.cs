using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectDisciplinesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToDisciplineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                table: "DisciplineNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineNumbers_DisciplineId",
                table: "DisciplineNumbers",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineNumbers_Disciplines_DisciplineId",
                table: "DisciplineNumbers",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineNumbers_Disciplines_DisciplineId",
                table: "DisciplineNumbers");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineNumbers_DisciplineId",
                table: "DisciplineNumbers");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "DisciplineNumbers");

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
    }
}
