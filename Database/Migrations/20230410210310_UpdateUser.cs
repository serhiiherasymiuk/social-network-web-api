using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileBackgroundUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "DisplayUsername",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileBackgroundUrl",
                table: "AspNetUsers");
            migrationBuilder.DropColumn(
                name: "DisplayUsername",
                table: "AspNetUsers");
        }
    }
}
