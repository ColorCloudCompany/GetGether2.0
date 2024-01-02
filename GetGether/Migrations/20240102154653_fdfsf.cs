﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGether.Migrations
{
    public partial class fdfsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Profiles_OrganizerUserNameId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Event_EventId",
                table: "EventParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Profiles_OrganizerUserNameId",
                table: "Event",
                column: "OrganizerUserNameId",
                principalTable: "Profiles",
                principalColumn: "UserNameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Event_EventId",
                table: "EventParticipant",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant",
                column: "ProfileUserNameId",
                principalTable: "Profiles",
                principalColumn: "UserNameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Profiles_OrganizerUserNameId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Event_EventId",
                table: "EventParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Profiles_OrganizerUserNameId",
                table: "Event",
                column: "OrganizerUserNameId",
                principalTable: "Profiles",
                principalColumn: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Event_EventId",
                table: "EventParticipant",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant",
                column: "ProfileUserNameId",
                principalTable: "Profiles",
                principalColumn: "UserNameId");
        }
    }
}
