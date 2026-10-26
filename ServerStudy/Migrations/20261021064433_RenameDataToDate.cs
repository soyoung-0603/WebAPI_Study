using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerStudy.Migrations
{
    /// <inheritdoc />
    public partial class RenameDataToDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "GameResults",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "GameResults",
                newName: "Data");
        }
    }
}
