using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmotionalSeesaw_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDaysTableFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_Days_DayId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_SummaryOfDayEntity_DayId",
                table: "SummaryOfDayEntity");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "SummaryOfDayEntity",
                newName: "CalendarId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "SummaryOfDayEntity",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfDayEntity_CalendarId",
                table: "SummaryOfDayEntity",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_Calendars_CalendarId",
                table: "SummaryOfDayEntity",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_Calendars_CalendarId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropIndex(
                name: "IX_SummaryOfDayEntity_CalendarId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SummaryOfDayEntity");

            migrationBuilder.RenameColumn(
                name: "CalendarId",
                table: "SummaryOfDayEntity",
                newName: "DayId");

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CalendarId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfDayEntity_DayId",
                table: "SummaryOfDayEntity",
                column: "DayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Days_CalendarId",
                table: "Days",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_Days_DayId",
                table: "SummaryOfDayEntity",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
