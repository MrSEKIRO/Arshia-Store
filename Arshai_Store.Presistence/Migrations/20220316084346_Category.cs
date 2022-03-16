using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arshai_Store.Presistence.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 3, 16, 12, 13, 46, 92, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 3, 16, 12, 13, 46, 96, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 3, 16, 12, 13, 46, 96, DateTimeKind.Local).AddTicks(7858));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 3, 15, 22, 57, 43, 406, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 3, 15, 22, 57, 43, 411, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 3, 15, 22, 57, 43, 411, DateTimeKind.Local).AddTicks(2128));
        }
    }
}
