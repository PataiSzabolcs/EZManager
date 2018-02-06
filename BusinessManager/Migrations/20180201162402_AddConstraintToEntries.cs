using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BusinessManager.Migrations
{
    public partial class AddConstraintToEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeeEarnerId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CaseId",
                table: "Entries",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_FeeEarnerId",
                table: "Entries",
                column: "FeeEarnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Cases_CaseId",
                table: "Entries",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_FeeEarnerId",
                table: "Entries",
                column: "FeeEarnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Cases_CaseId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_FeeEarnerId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_CaseId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_FeeEarnerId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "FeeEarnerId",
                table: "Entries");
        }
    }
}
