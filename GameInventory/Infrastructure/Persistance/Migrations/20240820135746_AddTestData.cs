using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameInventory.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PS1" },
                    { 2, "PS2" },
                    { 3, "PS3" },
                    { 4, "PS4" },
                    { 5, "Nintendo Switch" },
                    { 6, "PC" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Super Mario" },
                    { 2, "Ledgend Of Zelda" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steam" },
                    { 2, "Epic" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Format", "PlatformId", "SeriesId", "StoreId", "Title" },
                values: new object[,]
                {
                    { 1, "Digital", 6, null, 2, "Alan Wake 2" },
                    { 2, "Physical", 2, null, null, "Dark Chronicle" },
                    { 3, "Physical", 5, 2, null, "Legend of Zelda: Breath of the Wild" },
                    { 4, "Physical", 5, 1, null, "Super Mario Odyssey" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_StoreId",
                table: "Games",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Stores_StoreId",
                table: "Games",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Stores_StoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_StoreId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Games");
        }
    }
}
