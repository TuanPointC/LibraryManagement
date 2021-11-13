using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 16, 30, 24, 314, DateTimeKind.Local).AddTicks(6230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 15, 44, 3, 990, DateTimeKind.Local).AddTicks(4635));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 15, 44, 3, 990, DateTimeKind.Local).AddTicks(4635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 16, 30, 24, 314, DateTimeKind.Local).AddTicks(6230));
        }
    }
}
