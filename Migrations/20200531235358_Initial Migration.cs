using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Image = table.Column<string>(unicode: false, maxLength: 1024, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    CategoryId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId1",
                table: "Product",
                column: "CategoryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
