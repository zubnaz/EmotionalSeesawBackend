using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmotionalSeesaw_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayEntity_Calendars_CalendarId",
                table: "DayEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_DayEntity_DayId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_EmotionalStateEntity_EmotionalStateId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmotionalStateEntity",
                table: "EmotionalStateEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayEntity",
                table: "DayEntity");

            migrationBuilder.RenameTable(
                name: "EmotionalStateEntity",
                newName: "EmotionalStates");

            migrationBuilder.RenameTable(
                name: "DayEntity",
                newName: "Days");

            migrationBuilder.RenameIndex(
                name: "IX_DayEntity_CalendarId",
                table: "Days",
                newName: "IX_Days_CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmotionalStates",
                table: "EmotionalStates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Calendars_CalendarId",
                table: "Days",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_Days_DayId",
                table: "SummaryOfDayEntity",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_EmotionalStates_EmotionalStateId",
                table: "SummaryOfDayEntity",
                column: "EmotionalStateId",
                principalTable: "EmotionalStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Calendars_CalendarId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_Days_DayId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_EmotionalStates_EmotionalStateId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmotionalStates",
                table: "EmotionalStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.RenameTable(
                name: "EmotionalStates",
                newName: "EmotionalStateEntity");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "DayEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Days_CalendarId",
                table: "DayEntity",
                newName: "IX_DayEntity_CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmotionalStateEntity",
                table: "EmotionalStateEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayEntity",
                table: "DayEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayEntity_Calendars_CalendarId",
                table: "DayEntity",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_DayEntity_DayId",
                table: "SummaryOfDayEntity",
                column: "DayId",
                principalTable: "DayEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_EmotionalStateEntity_EmotionalStateId",
                table: "SummaryOfDayEntity",
                column: "EmotionalStateId",
                principalTable: "EmotionalStateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
