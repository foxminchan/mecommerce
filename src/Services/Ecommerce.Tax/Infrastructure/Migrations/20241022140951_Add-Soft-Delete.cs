using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Tax.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 22, 14, 9, 50, 782, DateTimeKind.Utc).AddTicks(
                    7808
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    17,
                    1,
                    30,
                    551,
                    DateTimeKind.Utc
                ).AddTicks(5417)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 14, 9, 50, 782, DateTimeKind.Utc).AddTicks(
                    7332
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    17,
                    1,
                    30,
                    551,
                    DateTimeKind.Utc
                ).AddTicks(4986)
            );

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "categories",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "calculations",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 22, 14, 9, 50, 777, DateTimeKind.Utc).AddTicks(
                    8345
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    17,
                    1,
                    30,
                    551,
                    DateTimeKind.Utc
                ).AddTicks(2184)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "calculations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 14, 9, 50, 776, DateTimeKind.Utc).AddTicks(
                    7615
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    17,
                    1,
                    30,
                    551,
                    DateTimeKind.Utc
                ).AddTicks(1814)
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "is_deleted", table: "categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 20, 17, 1, 30, 551, DateTimeKind.Utc).AddTicks(
                    5417
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    22,
                    14,
                    9,
                    50,
                    782,
                    DateTimeKind.Utc
                ).AddTicks(7808)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 17, 1, 30, 551, DateTimeKind.Utc).AddTicks(
                    4986
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    22,
                    14,
                    9,
                    50,
                    782,
                    DateTimeKind.Utc
                ).AddTicks(7332)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "calculations",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 20, 17, 1, 30, 551, DateTimeKind.Utc).AddTicks(
                    2184
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    22,
                    14,
                    9,
                    50,
                    777,
                    DateTimeKind.Utc
                ).AddTicks(8345)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "calculations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 17, 1, 30, 551, DateTimeKind.Utc).AddTicks(
                    1814
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    22,
                    14,
                    9,
                    50,
                    776,
                    DateTimeKind.Utc
                ).AddTicks(7615)
            );
        }
    }
}
