using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocenjevanje.API.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OcenjenFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcenjenFilm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocenjevalec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrikaznoIme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocenjevalec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrednost = table.Column<int>(type: "int", nullable: false),
                    DatumOcene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OcenjevalecId = table.Column<int>(type: "int", nullable: false),
                    OcenjenFilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocene_OcenjenFilm_OcenjenFilmId",
                        column: x => x.OcenjenFilmId,
                        principalTable: "OcenjenFilm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocene_Ocenjevalec_OcenjevalecId",
                        column: x => x.OcenjevalecId,
                        principalTable: "Ocenjevalec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_OcenjenFilmId",
                table: "Ocene",
                column: "OcenjenFilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_OcenjevalecId",
                table: "Ocene",
                column: "OcenjevalecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocene");

            migrationBuilder.DropTable(
                name: "OcenjenFilm");

            migrationBuilder.DropTable(
                name: "Ocenjevalec");
        }
    }
}
