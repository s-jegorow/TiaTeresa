using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiaTeresa.Migrations
{
    /// <inheritdoc />
    public partial class Geschichte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geschichte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitelSpanisch = table.Column<string>(type: "TEXT", nullable: false),
                    TitelDeutsch = table.Column<string>(type: "TEXT", nullable: false),
                    Spanisch = table.Column<string>(type: "TEXT", nullable: false),
                    Deutsch = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geschichte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vokabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Spanisch = table.Column<string>(type: "TEXT", nullable: false),
                    Deutsch = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vokabel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geschichte");

            migrationBuilder.DropTable(
                name: "Vokabel");
        }
    }
}
