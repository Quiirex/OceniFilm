using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Videoteka.API.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reziser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reziser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dolzina = table.Column<int>(type: "int", nullable: false),
                    ImdbOcena = table.Column<int>(type: "int", nullable: false),
                    PGOcena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetoIzdaje = table.Column<int>(type: "int", nullable: false),
                    Napovednik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReziserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmi_Reziser_ReziserId",
                        column: x => x.ReziserId,
                        principalTable: "Reziser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IgralecFilma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgralecFilma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IgralecFilma_Filmi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zanr_Filmi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmi_ReziserId",
                table: "Filmi",
                column: "ReziserId");

            migrationBuilder.CreateIndex(
                name: "IX_IgralecFilma_FilmId",
                table: "IgralecFilma",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Zanr_FilmId",
                table: "Zanr",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IgralecFilma");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Filmi");

            migrationBuilder.DropTable(
                name: "Reziser");
        }
    }
}
