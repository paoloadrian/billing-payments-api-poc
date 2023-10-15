using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicBilling.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "Id", "ClientId", "Month", "Type" },
                values: new object[,]
                {
                    { 1L, 1L, "202301", "SEWER" },
                    { 2L, 1L, "202301", "WATER" },
                    { 3L, 1L, "202301", "ELECTRICITY" },
                    { 4L, 1L, "202302", "SEWER" },
                    { 5L, 1L, "202302", "WATER" },
                    { 6L, 1L, "202302", "ELECTRICITY" },
                    { 7L, 2L, "202301", "SEWER" },
                    { 8L, 2L, "202301", "WATER" },
                    { 9L, 2L, "202301", "ELECTRICITY" },
                    { 10L, 2L, "202302", "SEWER" },
                    { 11L, 2L, "202302", "WATER" },
                    { 12L, 2L, "202302", "ELECTRICITY" },
                    { 13L, 3L, "202301", "SEWER" },
                    { 14L, 3L, "202301", "WATER" },
                    { 15L, 3L, "202301", "ELECTRICITY" },
                    { 16L, 3L, "202302", "SEWER" },
                    { 17L, 3L, "202302", "WATER" },
                    { 18L, 3L, "202302", "ELECTRICITY" },
                    { 19L, 4L, "202301", "SEWER" },
                    { 20L, 4L, "202301", "WATER" },
                    { 21L, 4L, "202301", "ELECTRICITY" },
                    { 22L, 4L, "202302", "SEWER" },
                    { 23L, 4L, "202302", "WATER" },
                    { 24L, 4L, "202302", "ELECTRICITY" },
                    { 25L, 5L, "202301", "SEWER" },
                    { 26L, 5L, "202301", "WATER" },
                    { 27L, 5L, "202301", "ELECTRICITY" },
                    { 28L, 5L, "202302", "SEWER" },
                    { 29L, 5L, "202302", "WATER" },
                    { 30L, 5L, "202302", "ELECTRICITY" }
                });

            migrationBuilder.InsertData(
                table: "ClientItems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Joseph Carlton" },
                    { 2L, "Maria Juarez" },
                    { 3L, "Albert Kenny" },
                    { 4L, "Jessica Phillips" },
                    { 5L, "Charles Johnson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
