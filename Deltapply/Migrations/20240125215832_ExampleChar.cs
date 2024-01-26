using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deltapply.Migrations
{
    /// <inheritdoc />
    public partial class ExampleChar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Example",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meanings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KanjiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Example_Kanjis_KanjiId",
                        column: x => x.KanjiId,
                        principalTable: "Kanjis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Char",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Special = table.Column<bool>(type: "bit", nullable: false),
                    ExampleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Char", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Char_Example_ExampleId",
                        column: x => x.ExampleId,
                        principalTable: "Example",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Char_ExampleId",
                table: "Char",
                column: "ExampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Example_KanjiId",
                table: "Example",
                column: "KanjiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Char");

            migrationBuilder.DropTable(
                name: "Example");
        }
    }
}
