using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "WhoUpdateId",
                table: "BorrowingRequest",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 17, 8, 4, 15, DateTimeKind.Local).AddTicks(5808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 16, 30, 24, 314, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HandledDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "WhoUpdateId",
                table: "BorrowingRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 13, 16, 30, 24, 314, DateTimeKind.Local).AddTicks(6230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 13, 17, 8, 4, 15, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HandledDate",
                table: "BorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
