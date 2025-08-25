using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PovarCRM.Migrations
{
    /// <inheritdoc />
    public partial class MakeClientNameRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "OrderCheck",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "OrderCheck",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1753, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishCount",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "OrderCheck",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "OrderCheck",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "DishCount",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
