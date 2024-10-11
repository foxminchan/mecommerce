using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "variants",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    833,
                    DateTimeKind.Utc
                ).AddTicks(9418),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    411,
                    DateTimeKind.Utc
                ).AddTicks(5437)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "variants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    833,
                    DateTimeKind.Utc
                ).AddTicks(8984),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    411,
                    DateTimeKind.Utc
                ).AddTicks(5134)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    812,
                    DateTimeKind.Utc
                ).AddTicks(5600),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    406,
                    DateTimeKind.Utc
                ).AddTicks(5412)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    812,
                    DateTimeKind.Utc
                ).AddTicks(5159),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    406,
                    DateTimeKind.Utc
                ).AddTicks(5053)
            );

            migrationBuilder.AddColumn<decimal>(
                name: "price_discount_price",
                table: "products",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true
            );

            migrationBuilder.AddColumn<decimal>(
                name: "price_original_price",
                table: "products",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "product_attributes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    794,
                    DateTimeKind.Utc
                ).AddTicks(8808),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    405,
                    DateTimeKind.Utc
                ).AddTicks(7249)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_attributes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    794,
                    DateTimeKind.Utc
                ).AddTicks(8426),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    405,
                    DateTimeKind.Utc
                ).AddTicks(6896)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "product_attribute_groups",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    795,
                    DateTimeKind.Utc
                ).AddTicks(9905),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    406,
                    DateTimeKind.Utc
                ).AddTicks(146)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_attribute_groups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    795,
                    DateTimeKind.Utc
                ).AddTicks(9587),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    405,
                    DateTimeKind.Utc
                ).AddTicks(9886)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    791,
                    DateTimeKind.Utc
                ).AddTicks(341),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    404,
                    DateTimeKind.Utc
                ).AddTicks(1991)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    790,
                    DateTimeKind.Utc
                ).AddTicks(9992),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    404,
                    DateTimeKind.Utc
                ).AddTicks(1623)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "brands",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    788,
                    DateTimeKind.Utc
                ).AddTicks(4563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    403,
                    DateTimeKind.Utc
                ).AddTicks(6426)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "brands",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    787,
                    DateTimeKind.Utc
                ).AddTicks(5112),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    9,
                    25,
                    5,
                    15,
                    14,
                    403,
                    DateTimeKind.Utc
                ).AddTicks(6049)
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "price_discount_price", table: "products");

            migrationBuilder.DropColumn(name: "price_original_price", table: "products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "variants",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 411, DateTimeKind.Utc).AddTicks(
                    5437
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    833,
                    DateTimeKind.Utc
                ).AddTicks(9418)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "variants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 411, DateTimeKind.Utc).AddTicks(
                    5134
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    833,
                    DateTimeKind.Utc
                ).AddTicks(8984)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 406, DateTimeKind.Utc).AddTicks(
                    5412
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    812,
                    DateTimeKind.Utc
                ).AddTicks(5600)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 406, DateTimeKind.Utc).AddTicks(
                    5053
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    812,
                    DateTimeKind.Utc
                ).AddTicks(5159)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "product_attributes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 405, DateTimeKind.Utc).AddTicks(
                    7249
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    794,
                    DateTimeKind.Utc
                ).AddTicks(8808)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_attributes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 405, DateTimeKind.Utc).AddTicks(
                    6896
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    794,
                    DateTimeKind.Utc
                ).AddTicks(8426)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "product_attribute_groups",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 406, DateTimeKind.Utc).AddTicks(
                    146
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    795,
                    DateTimeKind.Utc
                ).AddTicks(9905)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "product_attribute_groups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 405, DateTimeKind.Utc).AddTicks(
                    9886
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    795,
                    DateTimeKind.Utc
                ).AddTicks(9587)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 404, DateTimeKind.Utc).AddTicks(
                    1991
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    791,
                    DateTimeKind.Utc
                ).AddTicks(341)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 404, DateTimeKind.Utc).AddTicks(
                    1623
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    790,
                    DateTimeKind.Utc
                ).AddTicks(9992)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "brands",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 403, DateTimeKind.Utc).AddTicks(
                    6426
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    788,
                    DateTimeKind.Utc
                ).AddTicks(4563)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "brands",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 5, 15, 14, 403, DateTimeKind.Utc).AddTicks(
                    6049
                ),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    11,
                    13,
                    57,
                    51,
                    787,
                    DateTimeKind.Utc
                ).AddTicks(5112)
            );
        }
    }
}
