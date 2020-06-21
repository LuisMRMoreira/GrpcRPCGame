using Microsoft.EntityFrameworkCore.Migrations;

namespace GrpcServerRPS.Migrations
{
    public partial class gamesToPlayPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesToPlay",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesToPlay",
                table: "User");
        }
    }
}
