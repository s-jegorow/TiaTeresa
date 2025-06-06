using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiaTeresa.Migrations
{
    /// <inheritdoc />
    public partial class GeschichteAudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Audio",
                table: "Geschichte",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bild",
                table: "Geschichte",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audio",
                table: "Geschichte");

            migrationBuilder.DropColumn(
                name: "Bild",
                table: "Geschichte");
        }
    }
}
