using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PovarCRM.Migrations
{
    /// <inheritdoc />
    public partial class Addweighttodishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Dish",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Dish");
        }
    }
}
