using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomers.Infrastratiar.Migrations
{
    /// <inheritdoc />
    public partial class sed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "test", "test" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatagoryId", "Description", "Name", "NewPrice", "OldPrice" },
                values: new object[] { 1, 1, "test2", "test2", 300m, 0m });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "IimegName", "ProductId" },
                values: new object[] { 1, "test", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catagories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
