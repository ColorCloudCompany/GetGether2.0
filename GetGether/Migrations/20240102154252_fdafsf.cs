using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGether.Migrations
{
    public partial class fdafsf : Migration
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

            migrationBuilder.DropTable(
                name: "EventProfile");

            migrationBuilder.DropIndex(
                name: "IX_Event_OrganizerUserNameId",
                table: "Event");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerUserNameId",
                table: "Event",
                column: "OrganizerUserNameId");

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

            migrationBuilder.DropIndex(
                name: "IX_Event_OrganizerUserNameId",
                table: "Event");

            migrationBuilder.CreateTable(
                name: "EventProfile",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsUserNameId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProfile", x => new { x.EventsId, x.ParticipantsUserNameId });
                    table.ForeignKey(
                        name: "FK_EventProfile_Event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProfile_Profiles_ParticipantsUserNameId",
                        column: x => x.ParticipantsUserNameId,
                        principalTable: "Profiles",
                        principalColumn: "UserNameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerUserNameId",
                table: "Event",
                column: "OrganizerUserNameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_ParticipantsUserNameId",
                table: "EventProfile",
                column: "ParticipantsUserNameId");

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
    }
}
