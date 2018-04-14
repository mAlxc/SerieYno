using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SerieYno.Data.Migrations
{
    public partial class raf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaisonModel_EpisodeModel_EpID",
                table: "SaisonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieModel_SaisonModel_ID",
                table: "SerieModel");

            migrationBuilder.DropIndex(
                name: "IX_SaisonModel_EpID",
                table: "SaisonModel");

            migrationBuilder.DropColumn(
                name: "ID_saison",
                table: "SerieModel");

            migrationBuilder.DropColumn(
                name: "EpID",
                table: "SaisonModel");

            migrationBuilder.RenameColumn(
                name: "ID_ep",
                table: "SaisonModel",
                newName: "SerieId");

            migrationBuilder.AddColumn<Guid>(
                name: "SaisonId",
                table: "EpisodeModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SaisonModelID",
                table: "EpisodeModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "EpisodeModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaisonModel_SerieId",
                table: "SaisonModel",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeModel_SaisonId",
                table: "EpisodeModel",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeModel_SaisonModelID",
                table: "EpisodeModel",
                column: "SaisonModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeModel_SerieModel_SaisonId",
                table: "EpisodeModel",
                column: "SaisonId",
                principalTable: "SerieModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeModel_SaisonModel_SaisonModelID",
                table: "EpisodeModel",
                column: "SaisonModelID",
                principalTable: "SaisonModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaisonModel_SerieModel_SerieId",
                table: "SaisonModel",
                column: "SerieId",
                principalTable: "SerieModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_SaisonModel_EpisodeModel_EpID",
                table: "SaisonModel",
                column: "EpID",
                principalTable: "EpisodeModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieModel_SaisonModel_ID",
                table: "SerieModel",
                column: "ID",
                principalTable: "SaisonModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
