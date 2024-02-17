using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zaharie_Alexandra_Proiect4.Migrations
{
    /// <inheritdoc />
    public partial class Mentor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MentorID",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_MentorID",
                table: "Course",
                column: "MentorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Mentor_MentorID",
                table: "Course",
                column: "MentorID",
                principalTable: "Mentor",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Mentor_MentorID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropIndex(
                name: "IX_Course_MentorID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "MentorID",
                table: "Course");
        }
    }
}
