using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 14, 13, 47, 47, 449, DateTimeKind.Local).AddTicks(2455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 17, 8, 4, 15, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Name",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 17, 8, 4, 15, DateTimeKind.Local).AddTicks(5808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 14, 13, 47, 47, 449, DateTimeKind.Local).AddTicks(2455));
        }
    }
}
