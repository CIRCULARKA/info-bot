using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoBot.Data.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleAttributeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    ArticleEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAttributeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleAttributeEntity_ArticleEntity_ArticleEntityId",
                        column: x => x.ArticleEntityId,
                        principalTable: "ArticleEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAttributeEntity_ArticleEntityId",
                table: "ArticleAttributeEntity",
                column: "ArticleEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleAttributeEntity");

            migrationBuilder.DropTable(
                name: "ArticleEntity");
        }
    }
}
