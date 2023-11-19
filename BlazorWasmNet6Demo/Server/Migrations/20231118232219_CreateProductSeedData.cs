using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWasmNet6Demo.Server.Migrations
{
    public partial class CreateProductSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", 9.99m, "The Hitchhiker's Guide to the Galaxy" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", 7.99m, "Ready Player One" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "Ready Player Two is a 2020 science fiction novel by American author Ernest Cline. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation.", "https://upload.wikimedia.org/wikipedia/en/c/cd/Ready_Player_Two_-_book_cover.jpg", 8.99m, "Ready Player Two" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
