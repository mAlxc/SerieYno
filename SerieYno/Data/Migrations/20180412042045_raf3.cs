using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SerieYno.Data.Migrations
{
    public partial class raf3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeModel_SerieModel_SaisonId",
                table: "EpisodeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeModel_SaisonModel_SaisonModelID",
                table: "EpisodeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SaisonModel_SerieModel_SerieId",
                table: "SaisonModel");

            migrationBuilder.DropIndex(
                name: "IX_SaisonModel_SerieId",
                table: "SaisonModel");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeModel_SaisonId",
                table: "EpisodeModel");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeModel_SaisonModelID",
                table: "EpisodeModel");

            migrationBuilder.DropColumn(
                name: "SaisonId",
                table: "EpisodeModel");

            migrationBuilder.DropColumn(
                name: "SaisonModelID",
                table: "EpisodeModel");

            migrationBuilder.DropColumn(
                name: "description",
                table: "EpisodeModel");

            migrationBuilder.RenameColumn(
                name: "SerieId",
                table: "SaisonModel",
                newName: "ID_ep");

            migrationBuilder.AddColumn<Guid>(
                name: "ID_saison",
                table: "SerieModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EpID",
                table: "SaisonModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaisonModel_EpID",
                table: "SaisonModel",
                column: "EpID");

            migrationBuilder.DropTable(
    name: "Episode_VueModel");

            migrationBuilder.DropTable(
                name: "Serie_suivieModel");

            migrationBuilder.DropTable(
                name: "SerieModel");

            migrationBuilder.DropTable(
                name: "SaisonModel");

            migrationBuilder.DropTable(
                name: "EpisodeModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
