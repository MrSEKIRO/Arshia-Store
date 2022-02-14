using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arshai_Store.Presistence.Migrations
{
    public partial class IsActive_filed_for_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 2, 13, 17, 20, 22, 360, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 2, 13, 17, 20, 22, 364, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 2, 13, 17, 20, 22, 364, DateTimeKind.Local).AddTicks(1710));
        }
    }
}
