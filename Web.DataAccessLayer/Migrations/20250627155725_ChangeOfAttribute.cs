using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconUrl",
                table: "SocialLinks",
                newName: "IconClass");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconClass",
                table: "SocialLinks",
                newName: "IconUrl");
        }
    }
}
