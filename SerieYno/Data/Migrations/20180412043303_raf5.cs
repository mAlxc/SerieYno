using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SerieYno.Data.Migrations
{
    public partial class raf5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SerieModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    Name_serie = table.Column<string>(maxLength: 50, nullable: false),
                    Num_max_ep = table.Column<int>(nullable: false),
                    Num_max_saison = table.Column<int>(nullable: false),
                    Photo_serie = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SaisonModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Num_saison = table.Column<int>(nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaisonModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaisonModel_SerieModel_SerieId",
                        column: x => x.SerieId,
                        principalTable: "SerieModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serie_suivieModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Cod_suivie = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    ID_serie = table.Column<Guid>(nullable: false),
                    ID_user = table.Column<Guid>(nullable: false),
                    SerieID = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UtilisateurId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie_suivieModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serie_suivieModel_SerieModel_SerieID",
                        column: x => x.SerieID,
                        principalTable: "SerieModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Serie_suivieModel_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name_ep = table.Column<string>(nullable: true),
                    Num_ep = table.Column<int>(maxLength: 1, nullable: false),
                    SaisonId = table.Column<Guid>(nullable: false),
                    SaisonModelID = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EpisodeModel_SerieModel_SaisonId",
                        column: x => x.SaisonId,
                        principalTable: "SerieModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeModel_SaisonModel_SaisonModelID",
                        column: x => x.SaisonModelID,
                        principalTable: "SaisonModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episode_VueModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Cod_vue = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    EpisodeID = table.Column<Guid>(nullable: true),
                    ID_ep = table.Column<Guid>(nullable: false),
                    ID_user = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UtilisateurId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode_VueModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Episode_VueModel_EpisodeModel_EpisodeID",
                        column: x => x.EpisodeID,
                        principalTable: "EpisodeModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Episode_VueModel_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_VueModel_EpisodeID",
                table: "Episode_VueModel",
                column: "EpisodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_VueModel_UtilisateurId",
                table: "Episode_VueModel",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeModel_SaisonId",
                table: "EpisodeModel",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeModel_SaisonModelID",
                table: "EpisodeModel",
                column: "SaisonModelID");

            migrationBuilder.CreateIndex(
                name: "IX_SaisonModel_SerieId",
                table: "SaisonModel",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_suivieModel_SerieID",
                table: "Serie_suivieModel",
                column: "SerieID");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_suivieModel_UtilisateurId",
                table: "Serie_suivieModel",
                column: "UtilisateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode_VueModel");

            migrationBuilder.DropTable(
                name: "Serie_suivieModel");

            migrationBuilder.DropTable(
                name: "EpisodeModel");

            migrationBuilder.DropTable(
                name: "SaisonModel");

            migrationBuilder.DropTable(
                name: "SerieModel");
        }
    }
}
