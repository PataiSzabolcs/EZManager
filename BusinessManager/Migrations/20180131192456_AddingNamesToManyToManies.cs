using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BusinessManager.Migrations
{
    public partial class AddingNamesToManyToManies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdmin_Cases_CaseId",
                table: "CaseAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdmin_Users_UserId",
                table: "CaseAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAdmin_Clients_ClientId",
                table: "ClientAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAdmin_Users_UserId",
                table: "ClientAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentEvent_Documents_DocumentId",
                table: "DocumentEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentEvent_Events_EventId",
                table: "DocumentEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Users_UserId",
                table: "UserEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentEvent",
                table: "DocumentEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAdmin",
                table: "ClientAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseAdmin",
                table: "CaseAdmin");

            migrationBuilder.RenameTable(
                name: "UserEvent",
                newName: "UserEvents");

            migrationBuilder.RenameTable(
                name: "DocumentEvent",
                newName: "DocumentEvents");

            migrationBuilder.RenameTable(
                name: "ClientAdmin",
                newName: "ClientAdmins");

            migrationBuilder.RenameTable(
                name: "CaseAdmin",
                newName: "CaseAdmins");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvents",
                newName: "IX_UserEvents_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentEvent_EventId",
                table: "DocumentEvents",
                newName: "IX_DocumentEvents_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAdmin_UserId",
                table: "ClientAdmins",
                newName: "IX_ClientAdmins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseAdmin_UserId",
                table: "CaseAdmins",
                newName: "IX_CaseAdmins_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvents",
                table: "UserEvents",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentEvents",
                table: "DocumentEvents",
                columns: new[] { "DocumentId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAdmins",
                table: "ClientAdmins",
                columns: new[] { "ClientId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseAdmins",
                table: "CaseAdmins",
                columns: new[] { "CaseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdmins_Cases_CaseId",
                table: "CaseAdmins",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdmins_Users_UserId",
                table: "CaseAdmins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAdmins_Clients_ClientId",
                table: "ClientAdmins",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAdmins_Users_UserId",
                table: "ClientAdmins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentEvents_Documents_DocumentId",
                table: "DocumentEvents",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentEvents_Events_EventId",
                table: "DocumentEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Events_EventId",
                table: "UserEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdmins_Cases_CaseId",
                table: "CaseAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdmins_Users_UserId",
                table: "CaseAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAdmins_Clients_ClientId",
                table: "ClientAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAdmins_Users_UserId",
                table: "ClientAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentEvents_Documents_DocumentId",
                table: "DocumentEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentEvents_Events_EventId",
                table: "DocumentEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Events_EventId",
                table: "UserEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvents",
                table: "UserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentEvents",
                table: "DocumentEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAdmins",
                table: "ClientAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseAdmins",
                table: "CaseAdmins");

            migrationBuilder.RenameTable(
                name: "UserEvents",
                newName: "UserEvent");

            migrationBuilder.RenameTable(
                name: "DocumentEvents",
                newName: "DocumentEvent");

            migrationBuilder.RenameTable(
                name: "ClientAdmins",
                newName: "ClientAdmin");

            migrationBuilder.RenameTable(
                name: "CaseAdmins",
                newName: "CaseAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvent",
                newName: "IX_UserEvent_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentEvents_EventId",
                table: "DocumentEvent",
                newName: "IX_DocumentEvent_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAdmins_UserId",
                table: "ClientAdmin",
                newName: "IX_ClientAdmin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseAdmins_UserId",
                table: "CaseAdmin",
                newName: "IX_CaseAdmin_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentEvent",
                table: "DocumentEvent",
                columns: new[] { "DocumentId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAdmin",
                table: "ClientAdmin",
                columns: new[] { "ClientId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseAdmin",
                table: "CaseAdmin",
                columns: new[] { "CaseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdmin_Cases_CaseId",
                table: "CaseAdmin",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdmin_Users_UserId",
                table: "CaseAdmin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAdmin_Clients_ClientId",
                table: "ClientAdmin",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAdmin_Users_UserId",
                table: "ClientAdmin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentEvent_Documents_DocumentId",
                table: "DocumentEvent",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentEvent_Events_EventId",
                table: "DocumentEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Users_UserId",
                table: "UserEvent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
