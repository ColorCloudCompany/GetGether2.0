using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGether.Migrations
{
    public partial class AddEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizerUserNameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Profiles_OrganizerUserNameId",
                        column: x => x.OrganizerUserNameId,
                        principalTable: "Profiles",
                        principalColumn: "UserNameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipant",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ProfileUserNameId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipant", x => new { x.EventId, x.ProfileUserNameId });
                    table.ForeignKey(
                        name: "FK_EventParticipant_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipant_Profiles_ProfileUserNameId",
                        column: x => x.ProfileUserNameId,
                        principalTable: "Profiles",
                        principalColumn: "UserNameId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_EventParticipant_ProfileUserNameId",
                table: "EventParticipant",
                column: "ProfileUserNameId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_ParticipantsUserNameId",
                table: "EventProfile",
                column: "ParticipantsUserNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipant");

            migrationBuilder.DropTable(
                name: "EventProfile");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }
    }
}
