using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDefaultAuditSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "status",
                table: "warehouses",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    764,
                    DateTimeKind.Utc
                ).AddTicks(181),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    396,
                    DateTimeKind.Utc
                ).AddTicks(1011)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    763,
                    DateTimeKind.Utc
                ).AddTicks(9764),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    396,
                    DateTimeKind.Utc
                ).AddTicks(801)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    763,
                    DateTimeKind.Utc
                ).AddTicks(1556),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    763,
                    DateTimeKind.Utc
                ).AddTicks(849),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    742,
                    DateTimeKind.Utc
                ).AddTicks(1475),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    394,
                    DateTimeKind.Utc
                ).AddTicks(8151)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    741,
                    DateTimeKind.Utc
                ).AddTicks(3313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    394,
                    DateTimeKind.Utc
                ).AddTicks(7940)
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "warehouses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    396,
                    DateTimeKind.Utc
                ).AddTicks(1011),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    764,
                    DateTimeKind.Utc
                ).AddTicks(181)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    396,
                    DateTimeKind.Utc
                ).AddTicks(801),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    763,
                    DateTimeKind.Utc
                ).AddTicks(9764)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    763,
                    DateTimeKind.Utc
                ).AddTicks(1556)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    763,
                    DateTimeKind.Utc
                ).AddTicks(849)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_modified_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    394,
                    DateTimeKind.Utc
                ).AddTicks(8151),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    742,
                    DateTimeKind.Utc
                ).AddTicks(1475)
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "stocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(
                    2024,
                    10,
                    12,
                    14,
                    51,
                    22,
                    394,
                    DateTimeKind.Utc
                ).AddTicks(7940),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(
                    2024,
                    10,
                    13,
                    14,
                    22,
                    33,
                    741,
                    DateTimeKind.Utc
                ).AddTicks(3313)
            );
        }
    }
}
