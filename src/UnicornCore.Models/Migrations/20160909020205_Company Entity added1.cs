using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnicornCore.Models.Migrations
{
    public partial class CompanyEntityadded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CompanyId",
                table: "Persons",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Companies_CompanyId",
                table: "Persons",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Companies_CompanyId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CompanyId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
