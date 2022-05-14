using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Komentiranje.API.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komentator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrikaznoIme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KomentiranFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomentiranFilm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Komentarji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vsebina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumZapisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KomentiranFilmId = table.Column<int>(type: "int", nullable: false),
                    KomentatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentarji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentarji_Komentator_KomentatorId",
                        column: x => x.KomentatorId,
                        principalTable: "Komentator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentarji_KomentiranFilm_KomentiranFilmId",
                        column: x => x.KomentiranFilmId,
                        principalTable: "KomentiranFilm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentarji_KomentatorId",
                table: "Komentarji",
                column: "KomentatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentarji_KomentiranFilmId",
                table: "Komentarji",
                column: "KomentiranFilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentarji");

            migrationBuilder.DropTable(
                name: "Komentator");

            migrationBuilder.DropTable(
                name: "KomentiranFilm");
        }
    }
}
