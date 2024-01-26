using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deltapply.Migrations
{
    /// <inheritdoc />
    public partial class KanjiChar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Char",
                table: "Kanjis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Char",
                table: "Kanjis");
        }
    }
}
