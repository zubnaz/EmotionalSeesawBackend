using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmotionalSeesaw_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CalendarId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayEntity_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmotionalStateEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionalStateEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummaryOfDayEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    DayId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmotionalStateId = table.Column<Guid>(type: "uuid", nullable: true),
                    Advice = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryOfDayEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryOfDayEntity_DayEntity_DayId",
                        column: x => x.DayId,
                        principalTable: "DayEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SummaryOfDayEntity_EmotionalStateEntity_EmotionalStateId",
                        column: x => x.EmotionalStateId,
                        principalTable: "EmotionalStateEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayEntity_CalendarId",
                table: "DayEntity",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfDayEntity_DayId",
                table: "SummaryOfDayEntity",
                column: "DayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfDayEntity_EmotionalStateId",
                table: "SummaryOfDayEntity",
                column: "EmotionalStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryOfDayEntity");

            migrationBuilder.DropTable(
                name: "DayEntity");

            migrationBuilder.DropTable(
                name: "EmotionalStateEntity");
        }
    }
}
