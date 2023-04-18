﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecruiterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Recruiters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Recruiters");
        }
    }
}
