using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecuiterAndCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "ResumeUrl",
                table: "Candidates",
                newName: "Resume");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Recruiters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Recruiters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Recruiters");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "Candidates",
                newName: "ResumeUrl");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
