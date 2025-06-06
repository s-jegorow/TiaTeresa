using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiaTeresa.Migrations
{
    /// <inheritdoc />
    public partial class Sprichwort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sprichwort",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Spanisch = table.Column<string>(type: "TEXT", nullable: false),
                    Deutsch = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprichwort", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sprichwort");
        }
    }
}
