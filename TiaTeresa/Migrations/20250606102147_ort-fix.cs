using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiaTeresa.Migrations
{
    /// <inheritdoc />
    public partial class ortfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BeschreibungSpanisch = table.Column<string>(type: "TEXT", nullable: false),
                    BeschreibungDeutsch = table.Column<string>(type: "TEXT", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    Bild = table.Column<string>(type: "TEXT", nullable: false),
                    lon = table.Column<string>(type: "TEXT", nullable: false),
                    lat = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ort", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ort");
        }
    }
}
