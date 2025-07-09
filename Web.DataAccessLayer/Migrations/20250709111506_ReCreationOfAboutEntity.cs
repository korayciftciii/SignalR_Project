﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ReCreationOfAboutEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Abouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
