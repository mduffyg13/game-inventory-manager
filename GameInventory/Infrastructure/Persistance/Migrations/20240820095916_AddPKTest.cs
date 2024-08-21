using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameInventory.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddPKTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SeriesId",
                table: "Games",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Series_SeriesId",
                table: "Games",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Series_SeriesId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_SeriesId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
