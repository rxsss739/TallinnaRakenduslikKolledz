using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallinnaRakenduslikKolledz.Migrations
{
    /// <inheritdoc />
    public partial class uhawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTeacher",
                table: "Delinquent");

            migrationBuilder.AddColumn<string>(
                name: "TeacherOrStudent",
                table: "Delinquent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherOrStudent",
                table: "Delinquent");

            migrationBuilder.AddColumn<bool>(
                name: "IsTeacher",
                table: "Delinquent",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
