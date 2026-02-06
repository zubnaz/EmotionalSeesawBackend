using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmotionalSeesaw_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSummaryOfDayAndEmotionalStateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryOfDayEntity_EmotionalStates_EmotionalStateId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropIndex(
                name: "IX_SummaryOfDayEntity_EmotionalStateId",
                table: "SummaryOfDayEntity");

            migrationBuilder.DropColumn(
                name: "EmotionalStateId",
                table: "SummaryOfDayEntity");

            migrationBuilder.CreateTable(
                name: "EmotionalStateSummaryOfDay",
                columns: table => new
                {
                    EmotionalStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    SummaryOfDayId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionalStateSummaryOfDay", x => new { x.EmotionalStateId, x.SummaryOfDayId });
                    table.ForeignKey(
                        name: "FK_EmotionalStateSummaryOfDay_EmotionalStates_EmotionalStateId",
                        column: x => x.EmotionalStateId,
                        principalTable: "EmotionalStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmotionalStateSummaryOfDay_SummaryOfDayEntity_SummaryOfDayId",
                        column: x => x.SummaryOfDayId,
                        principalTable: "SummaryOfDayEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalStateSummaryOfDay_SummaryOfDayId",
                table: "EmotionalStateSummaryOfDay",
                column: "SummaryOfDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmotionalStateSummaryOfDay");

            migrationBuilder.AddColumn<Guid>(
                name: "EmotionalStateId",
                table: "SummaryOfDayEntity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfDayEntity_EmotionalStateId",
                table: "SummaryOfDayEntity",
                column: "EmotionalStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryOfDayEntity_EmotionalStates_EmotionalStateId",
                table: "SummaryOfDayEntity",
                column: "EmotionalStateId",
                principalTable: "EmotionalStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
