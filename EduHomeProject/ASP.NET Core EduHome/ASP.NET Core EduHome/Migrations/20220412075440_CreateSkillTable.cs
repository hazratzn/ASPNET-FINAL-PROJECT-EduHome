using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_EduHome.Migrations
{
    public partial class CreateSkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Communicatiom",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Devolopment",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "TeacherSkills");

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkills_SkillId",
                table: "TeacherSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSkills_SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "TeacherSkills");

            migrationBuilder.AddColumn<int>(
                name: "Communicatiom",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Devolopment",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Innovation",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeader",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
