using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_EduHome.Migrations
{
    public partial class CreateCourseCategoriesCourseFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apply",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificatiom",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCategories_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacCourseFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false),
                    Starts = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    ClassDuration = table.Column<string>(nullable: true),
                    SkillLevel = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Students = table.Column<int>(nullable: false),
                    Assesment = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacCourseFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacCourseFeatures_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_CourseId",
                table: "CourseCategories",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacCourseFeatures_CourseId",
                table: "TeacCourseFeatures",
                column: "CourseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "TeacCourseFeatures");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Apply",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Certificatiom",
                table: "Course");
        }
    }
}
