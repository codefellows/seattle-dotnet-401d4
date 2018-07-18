using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusMall.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Slice your bananas into smaller pieces!", "\\Images\\assets\\banana.jpg", "Banana Slicer", 4.99m, "BAN246" },
                    { 2, "Nothing is tastier than meat from a magical stallion!", "\\Images\\assets\\unicorn.jpg", "Unicorn Meat", 2.95m, "Uni481" },
                    { 3, "You can't spill the wine, if you can't drink it.", "\\Images\\assets\\wine-glass.jpg", "No-Spill Wine Glass", 7.50m, "Win637" },
                    { 4, "Look Fashionable in the rain", "\\Images\\assets\\boots.jpg", "Open-Toed Rain Boots", 11.55m, "BOOT348" },
                    { 5, "The Khaleesi approves this.", "\\Images\\assets\\dragon.jpg", "Dragon Meat", 1.50m, "DRGN123" },
                    { 6, "These are the bags you are looking for!", "\\Images\\assets\\bag.jpg", "R2D2 Bag", 19.00m, "R2D246" },
                    { 7, "Imagine a can that can fill itself.", "\\Images\\assets\\water-can.jpg", "Self Watering Can", 6.77m, "WTR729" },
                    { 8, "Cutting Pizza with scissors is cool.", "\\Images\\assets\\scissors.jpg", "Pizza Scissors", 2.99m, "SCS988" },
                    { 9, "Why sit down, when you can sit up!!", "\\Images\\assets\\chair.jpg", "Outverted Chair", 10.47m, "CHR654" },
                    { 10, "Break the fast all in one place!", "\\Images\\assets\\breakfast.jpg", "All-In-One Breakfast Maker", 14.39m, "BFST123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
