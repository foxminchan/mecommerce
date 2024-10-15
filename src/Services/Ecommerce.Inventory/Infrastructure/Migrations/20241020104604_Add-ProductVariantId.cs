using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "address_id", table: "warehouses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 20, 10, 46, 2, 641, DateTimeKind.Utc).AddTicks(
                    7204
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    18,
                    16,
                    20,
                    23,
                    11,
                    DateTimeKind.Utc
                ).AddTicks(8120)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 10, 46, 2, 641, DateTimeKind.Utc).AddTicks(
                    6843
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    18,
                    16,
                    20,
                    23,
                    11,
                    DateTimeKind.Utc
                ).AddTicks(7896)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 20, 10, 46, 2, 640, DateTimeKind.Utc).AddTicks(
                    8605
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    18,
                    16,
                    20,
                    23,
                    11,
                    DateTimeKind.Utc
                ).AddTicks(6076)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 10, 46, 2, 640, DateTimeKind.Utc).AddTicks(
                    8222
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    18,
                    16,
                    20,
                    23,
                    11,
                    DateTimeKind.Utc
                ).AddTicks(5874)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 20, 10, 46, 2, 622, DateTimeKind.Utc).AddTicks(
                    5401
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    18,
                    16,
                    20,
                    23,
                    10,
                    DateTimeKind.Utc
                ).AddTicks(3883)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 10, 46, 2, 621, DateTimeKind.Utc).AddTicks(
                    7237
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    18,
                    16,
                    20,
                    23,
                    10,
                    DateTimeKind.Utc
                ).AddTicks(3599)
            );

            migrationBuilder.AddColumn<long>(
                name: "product_variant_id",
                table: "stocks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "product_variant_id", table: "stocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 18, 16, 20, 23, 11, DateTimeKind.Utc).AddTicks(
                    8120
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    10,
                    46,
                    2,
                    641,
                    DateTimeKind.Utc
                ).AddTicks(7204)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 18, 16, 20, 23, 11, DateTimeKind.Utc).AddTicks(
                    7896
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    10,
                    46,
                    2,
                    641,
                    DateTimeKind.Utc
                ).AddTicks(6843)
            );

            migrationBuilder.AddColumn<Guid>(
                name: "address_id",
                table: "warehouses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 18, 16, 20, 23, 11, DateTimeKind.Utc).AddTicks(
                    6076
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    10,
                    46,
                    2,
                    640,
                    DateTimeKind.Utc
                ).AddTicks(8605)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 18, 16, 20, 23, 11, DateTimeKind.Utc).AddTicks(
                    5874
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    10,
                    46,
                    2,
                    640,
                    DateTimeKind.Utc
                ).AddTicks(8222)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 10, 18, 16, 20, 23, 10, DateTimeKind.Utc).AddTicks(
                    3883
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    10,
                    46,
                    2,
                    622,
                    DateTimeKind.Utc
                ).AddTicks(5401)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 18, 16, 20, 23, 10, DateTimeKind.Utc).AddTicks(
                    3599
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    20,
                    10,
                    46,
                    2,
                    621,
                    DateTimeKind.Utc
                ).AddTicks(7237)
            );
        }
    }
}
