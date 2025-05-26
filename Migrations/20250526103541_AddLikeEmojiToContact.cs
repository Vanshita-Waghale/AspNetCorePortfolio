using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VicStarDevPortfolio.Migrations
{
    public partial class AddLikeEmojiToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LikeEmoji",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeEmoji",
                table: "Contacts");
        }
    }
}
