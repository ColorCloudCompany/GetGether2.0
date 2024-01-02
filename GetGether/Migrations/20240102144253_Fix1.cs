using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGether.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant");

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
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                table: "EventParticipant",
                column: "ProfileUserNameId",
                principalTable: "Profiles",
                principalColumn: "UserNameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
