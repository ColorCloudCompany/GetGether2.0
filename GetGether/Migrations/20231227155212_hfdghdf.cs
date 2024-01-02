﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGether.Migrations
{
    public partial class hfdghdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNamee",
                table: "loginUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "loginUsers",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_loginUsers_Id",
                        column: x => x.Id,
                        principalTable: "loginUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "loginUsers",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserNamee",
                table: "loginUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}