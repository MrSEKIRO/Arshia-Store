using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arshai_Store.Presistence.Migrations
{
    public partial class add_ViewCount_to_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 3, 27, 12, 42, 44, 694, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 3, 27, 12, 42, 44, 698, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 3, 27, 12, 42, 44, 698, DateTimeKind.Local).AddTicks(8038));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 3, 17, 12, 45, 39, 60, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 3, 17, 12, 45, 39, 64, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 3, 17, 12, 45, 39, 64, DateTimeKind.Local).AddTicks(7250));
        }
    }
}
