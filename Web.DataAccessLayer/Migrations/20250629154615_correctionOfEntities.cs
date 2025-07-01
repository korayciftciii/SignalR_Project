using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class correctionOfEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpeningHours_FooterContents_FooterContentId",
                table: "OpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_FooterContents_FooterContentId",
                table: "SocialLinks");

            migrationBuilder.DropIndex(
                name: "IX_SocialLinks_FooterContentId",
                table: "SocialLinks");

            migrationBuilder.DropIndex(
                name: "IX_OpeningHours_FooterContentId",
                table: "OpeningHours");

            migrationBuilder.DropColumn(
                name: "FooterContentId",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "FooterContentId",
                table: "OpeningHours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FooterContentId",
                table: "SocialLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FooterContentId",
                table: "OpeningHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_FooterContentId",
                table: "SocialLinks",
                column: "FooterContentId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHours_FooterContentId",
                table: "OpeningHours",
                column: "FooterContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningHours_FooterContents_FooterContentId",
                table: "OpeningHours",
                column: "FooterContentId",
                principalTable: "FooterContents",
                principalColumn: "FooterContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_FooterContents_FooterContentId",
                table: "SocialLinks",
                column: "FooterContentId",
                principalTable: "FooterContents",
                principalColumn: "FooterContentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
