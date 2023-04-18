using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifyentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Candidates");
        }
    }
}
