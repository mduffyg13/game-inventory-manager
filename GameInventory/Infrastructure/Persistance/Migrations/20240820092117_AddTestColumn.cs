using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInventory.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddTestColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Games");
        }
    }
}
