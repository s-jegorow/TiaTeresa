using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiaTeresa.Migrations
{
    /// <inheritdoc />
    public partial class ortcopyright : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BildCopyright",
                table: "Ort",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BildCopyright",
                table: "Ort");
        }
    }
}
