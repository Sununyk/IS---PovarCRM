using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PovarCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryConsistKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    OrderCheckId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    DishCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consist_OrderCheckId_DishId", x => new { x.OrderCheckId, x.DishId });
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
                name: "Recipes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    DishProductId = table.Column<int>(type: "int", nullable: false),
                    CountOfUnits = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consist_DishProductId_DishId", x => new { x.DishProductId, x.DishId });
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
                name: "IX_Items_DishId",
                table: "Items",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "UQ_Dish_Unit",
                table: "Recipes",
                columns: new[] { "DishId", "DishProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: true),
                    OrderCheckId = table.Column<int>(type: "int", nullable: true),
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
        }
    }
}
