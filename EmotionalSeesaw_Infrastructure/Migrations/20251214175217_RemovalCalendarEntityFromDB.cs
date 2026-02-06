using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmotionalSeesaw_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovalCalendarEntityFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_Calendars_CalendarId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.RenameColumn(
                name: "CalendarId",
                table: "SummaryOfDayEntity",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryOfDayEntity_CalendarId",
                table: "SummaryOfDayEntity",
                newName: "IX_SummaryOfDayEntity_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_AspNetUsers_UserId",
                table: "SummaryOfDayEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_AspNetUsers_UserId",
                table: "SummaryOfDayEntity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SummaryOfDayEntity",
                newName: "CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryOfDayEntity_UserId",
                table: "SummaryOfDayEntity",
                newName: "IX_SummaryOfDayEntity_CalendarId");

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Calendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_Calendars_CalendarId",
                table: "SummaryOfDayEntity",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
