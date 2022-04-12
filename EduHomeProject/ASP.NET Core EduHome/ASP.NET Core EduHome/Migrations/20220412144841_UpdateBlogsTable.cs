using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_EduHome.Migrations
{
    public partial class UpdateBlogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blog");
        }
    }
}
