using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PovarCRM.Migrations
{
    /// <inheritdoc />
    public partial class DishProductWeightandUnitweight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Unit");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "DishProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "DishProduct");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Unit",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
