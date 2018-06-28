using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoClass17.Migrations
{
    public partial class maketricks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyPID",
                table: "Songs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyPID",
                table: "Songs");
        }
    }
}
