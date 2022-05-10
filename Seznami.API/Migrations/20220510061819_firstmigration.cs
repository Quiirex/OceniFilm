using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seznami.API.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uporabnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrikaznoIme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeznamiFilmov",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    NazivSeznama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeznamiFilmov", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeznamiFilmov_Uporabnik_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeznamFilmovId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_SeznamiFilmov_SeznamFilmovId",
                        column: x => x.SeznamFilmovId,
                        principalTable: "SeznamiFilmov",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_SeznamFilmovId",
                table: "Film",
                column: "SeznamFilmovId");

            migrationBuilder.CreateIndex(
                name: "IX_SeznamiFilmov_UporabnikId",
                table: "SeznamiFilmov",
                column: "UporabnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "SeznamiFilmov");

            migrationBuilder.DropTable(
                name: "Uporabnik");
        }
    }
}
