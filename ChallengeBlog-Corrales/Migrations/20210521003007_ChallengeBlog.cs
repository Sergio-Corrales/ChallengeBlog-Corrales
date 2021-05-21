using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeBlog_Corrales.Migrations
{
    public partial class ChallengeBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Post");
        }
    }
}
