using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitySkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    CandidateGID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillGID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => new { x.CandidateGID, x.SkillGID });
                    table.ForeignKey(
                        name: "FK_CandidateSkills_CandidateGID",
                        column: x => x.CandidateGID,
                        principalTable: "Candidates",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_SkillGID",
                        column: x => x.SkillGID,
                        principalTable: "Skills",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_SkillGID",
                table: "CandidateSkills",
                column: "SkillGID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkills");
        }
    }
}
