using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiaTeresa.Migrations
{
    /// <inheritdoc />
    public partial class SprichwortUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BedeutungDeutsch",
                table: "Sprichwort",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BedeutungSpanisch",
                table: "Sprichwort",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bilddatei",
                table: "Sprichwort",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedeutungDeutsch",
                table: "Sprichwort");

            migrationBuilder.DropColumn(
                name: "BedeutungSpanisch",
                table: "Sprichwort");

            migrationBuilder.DropColumn(
                name: "Bilddatei",
                table: "Sprichwort");
        }
    }
}
