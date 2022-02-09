using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Terror" },
                    { 2, "Suspense" },
                    { 3, "Comedia" },
                    { 4, "Romance" },
                    { 5, "Ficção" },
                    { 6, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "CategoryId", "Isbn", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Eric Evans", 1, "8721893718", 50m, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { 2, "Robert C. Martin", 2, "7632153123", 35m, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agile Principles, Patterns, and Practices in C#" },
                    { 3, "Robert C. Martin", 3, "6372168304", 22m, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { 4, "Vaughn Vernon", 4, "7812382103", 34m, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implementing Domain-Driven Design" },
                    { 5, "Scott Millet", 2, "8812936542", 15m, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patterns, Principles, and Practices of Domain-Driven Design" },
                    { 6, "Martin Fowler", 1, "5892187320", 13m, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring: Improving the Design of Existing Code" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
