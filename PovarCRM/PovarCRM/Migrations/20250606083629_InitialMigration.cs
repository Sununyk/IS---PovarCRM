using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PovarCRM.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naming = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DishType__3214EC070FA47347", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderChe__3214EC07DDCE8732", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naming = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Unit__3214EC07D9854487", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naming = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    DishTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dish__3214EC073FCC58D9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Dish__DishTypeId__4E88ABD4",
                        column: x => x.DishTypeId,
                        principalTable: "DishType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naming = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DishProd__3214EC0793517D24", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DishProdu__UnitI__5629CD9C",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    OrderCheckId = table.Column<int>(type: "int", nullable: true),
                    DishId = table.Column<int>(type: "int", nullable: true),
                    DishCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Item__DishId__60A75C0F",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Item__OrderCheck__5FB337D6",
                        column: x => x.OrderCheckId,
                        principalTable: "OrderCheck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: true),
                    DishProductId = table.Column<int>(type: "int", nullable: true),
                    CountOfUnits = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Recipe__DishId__59063A47",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Recipe__DishProd__59FA5E80",
                        column: x => x.DishProductId,
                        principalTable: "DishProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishTypeId",
                table: "Dish",
                column: "DishTypeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Dish__EF1B1C3A7896333B",
                table: "Dish",
                column: "Naming",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishProduct_UnitId",
                table: "DishProduct",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "UQ__DishProd__EF1B1C3AB945F017",
                table: "DishProduct",
                column: "Naming",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__DishType__EF1B1C3ABD2469FD",
                table: "DishType",
                column: "Naming",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_DishId",
                table: "Item",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_OrderCheckId",
                table: "Item",
                column: "OrderCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_DishProductId",
                table: "Recipe",
                column: "DishProductId");

            migrationBuilder.CreateIndex(
                name: "UQ_Dish_Unit",
                table: "Recipe",
                columns: new[] { "DishId", "DishProductId" },
                unique: true,
                filter: "[DishId] IS NOT NULL AND [DishProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Unit__EF1B1C3A358C331F",
                table: "Unit",
                column: "Naming",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "OrderCheck");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "DishProduct");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
