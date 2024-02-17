using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zaharie_Alexandra_Proiect4.Migrations
{
    /// <inheritdoc />
    public partial class Language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_LanguageID",
                table: "Course",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Language_LanguageID",
                table: "Course",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Language_LanguageID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Course_LanguageID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Course");
        }
    }
}
