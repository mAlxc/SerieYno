using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SerieYno.Data.Migrations
{
    public partial class SerieInit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "SerieModel");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SerieModel",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_serie",
                table: "SerieModel",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo_serie",
                table: "SerieModel",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerieModel",
                table: "SerieModel",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SerieModel",
                table: "SerieModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SerieModel");

            migrationBuilder.DropColumn(
                name: "Name_serie",
                table: "SerieModel");

            migrationBuilder.DropColumn(
                name: "Photo_serie",
                table: "SerieModel");

            migrationBuilder.RenameTable(
                name: "SerieModel",
                newName: "Serie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                column: "ID");
        }
    }
}
