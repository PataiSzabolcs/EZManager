using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BusinessManager.Migrations
{
    public partial class AddEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BillableCaseId = table.Column<int>(nullable: true),
                    BillableUserId = table.Column<int>(nullable: true),
                    Hours = table.Column<double>(nullable: false),
                    Narrative = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Billables_BillableCaseId_BillableUserId",
                        columns: x => new { x.BillableCaseId, x.BillableUserId },
                        principalTable: "Billables",
                        principalColumns: new[] { "CaseId", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_BillableCaseId_BillableUserId",
                table: "Entries",
                columns: new[] { "BillableCaseId", "BillableUserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
