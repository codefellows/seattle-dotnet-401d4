using Microsoft.EntityFrameworkCore.Migrations;

namespace Cohort4ECommerce.Migrations
{
    public partial class addPostsseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Contents", "Title" },
                values: new object[,]
                {
                    { 1, "Seriously, they are my best friends. They really know me.", "My cats are my best friends" },
                    { 2, "Tacos make me happy, they are delicious. They make all the problems go away.", "Tacos are Great" },
                    { 3, "Elsa is not a princess. She is a queen. Therefore better than all other princesses.", "Disney Princess" },
                    { 4, "Dear Coffee, I love you. That is all.", "Coffee is life" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
