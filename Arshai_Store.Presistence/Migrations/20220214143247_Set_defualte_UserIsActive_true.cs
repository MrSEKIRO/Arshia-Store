using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arshai_Store.Presistence.Migrations
{
    public partial class Set_defualte_UserIsActive_true : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 2, 14, 18, 2, 45, 814, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 2, 14, 18, 2, 45, 822, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 2, 14, 18, 2, 45, 822, DateTimeKind.Local).AddTicks(8377));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 2, 14, 16, 44, 57, 133, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 2, 14, 16, 44, 57, 137, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 2, 14, 16, 44, 57, 137, DateTimeKind.Local).AddTicks(5558));
        }
    }
}
