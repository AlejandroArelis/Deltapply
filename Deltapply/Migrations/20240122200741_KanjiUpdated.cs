using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deltapply.Migrations
{
    /// <inheritdoc />
    public partial class KanjiUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saved",
                table: "Kanjis",
                newName: "Checked");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Kanjis",
                newName: "Jlpt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Jlpt",
                table: "Kanjis",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "Checked",
                table: "Kanjis",
                newName: "Saved");
        }
    }
}
